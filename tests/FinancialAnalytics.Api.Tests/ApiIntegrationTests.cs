using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using FinancialAnalytics.Api.Contracts.AnalyticalRecords;
using FinancialAnalytics.Api.Contracts.Pagination;
using FinancialAnalytics.Api.Contracts.Pipeline;
using FinancialAnalytics.Api.Contracts.Reports;
using FinancialAnalytics.Api.Contracts.Source;
using FinancialAnalytics.Api.Contracts.Staging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Testcontainers.MsSql;
using Xunit;

namespace FinancialAnalytics.Api.Tests;

public sealed class ApiIntegrationTests : IAsyncLifetime
{
    private readonly MsSqlContainer sqlServer = new MsSqlBuilder()
        .WithPassword(TestDatabaseSeed.SqlServerPassword)
        .Build();
    private WebApplicationFactory<Program> factory = null!;
    private HttpClient client = null!;

    public async Task InitializeAsync()
    {
        await TestDatabaseSeed.StartSqlServerAsync(sqlServer);
        await using (var fakeErp = CreateFakeErpContext())
        await using (var analytics = CreateAnalyticsContext())
        {
            await fakeErp.Database.MigrateAsync();
            await analytics.Database.MigrateAsync();
            await TestDatabaseSeed.UseReducedFakeErpAsync(fakeErp);
            await ClearAnalyticsAsync(analytics);
        }

        factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.UseSetting("ConnectionStrings:FakeErp", GetDatabaseConnectionString("FakeErp_Test"));
            builder.UseSetting("ConnectionStrings:FinancialAnalytics", GetDatabaseConnectionString("FinancialAnalytics_Test"));
        });
        client = factory.CreateClient();
    }

    public async Task DisposeAsync()
    {
        client.Dispose();
        await factory.DisposeAsync();
        await sqlServer.DisposeAsync();
    }

    [Fact]
    public async Task Resource_endpoints_work_before_and_after_pipeline_run()
    {
        var sourceBeforeRun = await GetPageItems<SourceTransactionResponse>("/api/source/transactions");
        sourceBeforeRun.Should().HaveCount(20);

        var analyticalRecordsBeforeRun = await GetPageItems<AnalyticalRecordResponse>("/api/analytical-records");
        analyticalRecordsBeforeRun.Should().BeEmpty();

        var runResponse = await client.PostAsync("/api/pipeline/run", null);
        runResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var run = await runResponse.Content.ReadFromJsonAsync<PipelineRunResponse>();

        run.Should().NotBeNull();
        run!.PipelineRunId.Should().BePositive();
        run.Status.Should().Be("Completed");
        run!.RecordsExtracted.Should().Be(20);
        run.RecordsTransformed.Should().Be(20);
        run.RecordsValidated.Should().Be(20);
        run.RecordsLoaded.Should().Be(20);
        run.RecordsInserted.Should().Be(20);
        run.RecordsAlreadyExisting.Should().Be(0);
        run.RecordsFailed.Should().Be(0);
        run.Validation!.IsValid.Should().BeTrue();

        var details = await client.GetFromJsonAsync<PipelineRunResponse>($"/api/pipeline/runs/{run.PipelineRunId}");
        details!.RecordsLoaded.Should().Be(20);
        details.RecordsInserted.Should().Be(20);
        details.RecordsAlreadyExisting.Should().Be(0);

        var source = await GetPageItems<SourceTransactionResponse>("/api/source/transactions");
        source.Should().HaveCount(20);
        source![0].SourceTransactionId.Should().NotBeNullOrWhiteSpace();

        var staging = await GetPageItems<StagingTransactionResponse>($"/api/pipeline/runs/{run.PipelineRunId}/staging");
        staging.Should().HaveCount(20);
        staging!.Should().OnlyContain(x => x.PipelineRunId == run.PipelineRunId);

        var transformations = await GetPageItems<PipelineTransformationResponse>($"/api/pipeline/runs/{run.PipelineRunId}/transformations");
        transformations.Should().HaveCount(20);
        transformations!.Should().Contain(x => x.SourceAccountCode == "4000" && x.CanonicalAccountCode == "REV-PROD" && x.CanonicalAccountName == "Product Revenue");
        transformations.Should().Contain(x => x.SourceAccountCode == "4010" && x.CanonicalAccountCode == "REV-SERV" && x.CanonicalAccountName == "Service Revenue");
        transformations.Should().Contain(x => x.SourceAccountCode == "5000" && x.CanonicalAccountCode == "COGS-MAT" && x.CanonicalAccountName == "Materials");
        transformations.Should().Contain(x => x.SourceAccountCode == "6000" && x.CanonicalAccountCode == "OPEX-SAL" && x.CanonicalAccountName == "Salaries");
        var firstTransformation = transformations[0];
        firstTransformation.AccountKey.Should().Be(1);
        firstTransformation.EntityName.Should().Be("Northstar US");
        firstTransformation.EntityKey.Should().Be(1);
        firstTransformation.DateKey.Should().Be(firstTransformation.TransactionDate.Year * 10000 + firstTransformation.TransactionDate.Month * 100 + firstTransformation.TransactionDate.Day);
        firstTransformation.CurrencyName.Should().Be("US Dollar");
        firstTransformation.CurrencyKey.Should().Be(1);

        var validation = await client.GetFromJsonAsync<PipelineValidationResponse>($"/api/pipeline/runs/{run.PipelineRunId}/validation");
        validation!.IsValid.Should().BeTrue();
        validation.ReconciliationPassed.Should().BeTrue();
        validation.ReconciliationByCurrency.Should().BeEquivalentTo([
            new CurrencyReconciliationResponse("CAD", 16000m, 16000m, 0m),
            new CurrencyReconciliationResponse("USD", 28000m, 28000m, 0m)
        ]);

        var analyticalRecords = await GetPageItems<AnalyticalRecordResponse>("/api/analytical-records");
        analyticalRecords.Should().HaveCount(20);
        analyticalRecords!.Should().Contain(x => x.AccountCode == "REV-PROD" && x.AccountCategory == "Revenue" && x.EntityCode == "US" && x.CurrencyCode == "USD");
    }

    [Fact]
    public async Task Second_pipeline_run_is_idempotent_through_api()
    {
        var firstResponse = await client.PostAsync("/api/pipeline/run", null);
        firstResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var secondResponse = await client.PostAsync("/api/pipeline/run", null);
        var secondRun = await secondResponse.Content.ReadFromJsonAsync<PipelineRunResponse>();

        secondResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        secondRun!.RecordsLoaded.Should().Be(20);
        secondRun.RecordsInserted.Should().Be(0);
        secondRun.RecordsAlreadyExisting.Should().Be(20);
        secondRun.RecordsFailed.Should().Be(0);
        (await GetPageItems<AnalyticalRecordResponse>("/api/analytical-records")).Should().HaveCount(20);
    }

    [Fact]
    public async Task Validation_failure_returns_unprocessable_entity_with_pipeline_diagnostics()
    {
        var response = await client.PostAsync("/api/pipeline/run?scenario=validation-failure", null);
        var run = await response.Content.ReadFromJsonAsync<PipelineRunResponse>();

        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        run.Should().NotBeNull();
        run!.Status.Should().Be("Failed");
        run.Validation.Should().NotBeNull();
        run.Validation!.IsValid.Should().BeFalse();
        run.Validation.InvalidAmounts.Should().Be(0);
        run.Validation.ReconciliationPassed.Should().BeFalse();
        run.Validation.ReconciliationByCurrency.Should().ContainSingle(item =>
            item.Currency == "CAD" && item.Difference == -10000m);
        run.Validation.Errors.Should().Contain(error =>
            error.Phase == "Validate"
            && error.Code == "ReconciliationMismatch"
            && error.Message.Contains("CAD"));

        var persistedValidation = await client.GetFromJsonAsync<PipelineValidationResponse>(
            $"/api/pipeline/runs/{run.PipelineRunId}/validation");

        persistedValidation.Should().NotBeNull();
        persistedValidation!.IsValid.Should().BeFalse();
        persistedValidation.ReconciliationPassed.Should().BeFalse();
        persistedValidation.ReconciliationByCurrency.Should().ContainSingle(item =>
            item.Currency == "CAD" && item.Difference == -10000m);
    }

    [Fact]
    public async Task Transform_failure_scenario_is_consistent_between_source_and_pipeline()
    {
        var source = await GetPageItems<SourceTransactionResponse>(
            "/api/source/transactions?scenario=transform-failure");
        var sourceRecord = source!.Single(x => x.SourceTransactionId == "A005");

        source.Should().HaveCount(20);
        sourceRecord.TransactionDate.Should().Be(new DateOnly(2026, 1, 21));

        var response = await client.PostAsync("/api/pipeline/run?scenario=transform-failure", null);
        var run = await response.Content.ReadFromJsonAsync<PipelineRunResponse>();

        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        run.Should().NotBeNull();
        run!.RecordsExtracted.Should().Be(20);
        run.RecordsTransformed.Should().Be(19);
        run.RecordsValidated.Should().Be(0);
        run.RecordsLoaded.Should().Be(0);
        run.Validation.Should().BeNull();
        run.Errors.Should().ContainSingle(error =>
            error.Phase == "Transform"
            && error.Code == "MissingDateDimension"
            && error.SourceTransactionId == "A005");

        await using (var analytics = CreateAnalyticsContext())
        {
            var persistedError = await analytics.PipelineErrors.SingleAsync(x => x.PipelineRunId == run.PipelineRunId);
            persistedError.Stage.Should().Be("Transform");
            persistedError.ErrorCode.Should().Be("MissingDateDimension");
            persistedError.SourceTransactionId.Should().Be("A005");
        }

        var transformations = await GetPageItems<PipelineTransformationResponse>(
            $"/api/pipeline/runs/{run.PipelineRunId}/transformations");
        transformations.Should().ContainSingle(x =>
            x.SourceTransactionId == "A005"
            && x.ErrorCode == "MissingDateDimension"
            && x.ErrorMessage!.Contains("2021-01-21"));

        var details = await client.GetFromJsonAsync<PipelineRunResponse>(
            $"/api/pipeline/runs/{run.PipelineRunId}");
        details!.Errors.Should().ContainSingle(error =>
            error.Code == "MissingDateDimension" && error.SourceTransactionId == "A005");
    }

    [Fact]
    public async Task Validation_failure_scenario_reaches_validation_and_reports_currency_mismatch()
    {
        var response = await client.PostAsync("/api/pipeline/run?scenario=validation-failure", null);
        var run = await response.Content.ReadFromJsonAsync<PipelineRunResponse>();

        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        run.Should().NotBeNull();
        run!.RecordsExtracted.Should().Be(20);
        run.RecordsTransformed.Should().Be(20);
        run.RecordsValidated.Should().Be(20);
        run.RecordsLoaded.Should().Be(0);
        run.Validation.Should().NotBeNull();
        run.Validation!.Duplicates.Should().Be(0);
        run.Validation.ReconciliationPassed.Should().BeFalse();
        run.Validation.ReconciliationByCurrency.Should().ContainSingle(item =>
            item.Currency == "CAD" && item.Difference == -10000m);
        run.Validation.Errors.Should().Contain(error =>
            error.Phase == "Validate"
            && error.Code == "ReconciliationMismatch"
            && error.Message.Contains("CAD"));

        var transformations = await GetPageItems<PipelineTransformationResponse>(
            $"/api/pipeline/runs/{run.PipelineRunId}/transformations");
        transformations.Should().HaveCount(20);
        transformations!.Count(x => x.SourceTransactionId == "A005").Should().Be(1);
    }

    [Fact]
    public async Task Reset_pipeline_clears_execution_state_preserves_source_and_allows_a_new_run()
    {
        var firstRunResponse = await client.PostAsync("/api/pipeline/run", null);
        firstRunResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var resetResponse = await client.DeleteAsync("/api/pipeline/reset");
        resetResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var reset = await resetResponse.Content.ReadFromJsonAsync<PipelineResetResponse>();

        reset.Should().NotBeNull();
        reset!.RecordsDeleted.Facts.Should().Be(20);
        reset.RecordsDeleted.Staging.Should().Be(20);
        reset.RecordsDeleted.PipelineRuns.Should().Be(1);
        (await GetPageItems<SourceTransactionResponse>("/api/source/transactions")).Should().HaveCount(20);
        (await GetPageItems<AnalyticalRecordResponse>("/api/analytical-records")).Should().BeEmpty();

        await using (var analytics = CreateAnalyticsContext())
        {
            (await analytics.DimAccounts.CountAsync()).Should().Be(4);
            (await analytics.DimEntities.CountAsync()).Should().Be(2);
            (await analytics.DimDates.CountAsync()).Should().Be(730);
            (await analytics.DimCurrencies.CountAsync()).Should().Be(2);
            (await analytics.PipelineRuns.CountAsync()).Should().Be(0);
            (await analytics.StgTransactions.CountAsync()).Should().Be(0);
            (await analytics.FactGl.CountAsync()).Should().Be(0);
        }

        var secondRunResponse = await client.PostAsync("/api/pipeline/run", null);
        var secondRun = await secondRunResponse.Content.ReadFromJsonAsync<PipelineRunResponse>();

        secondRunResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        secondRun!.RecordsInserted.Should().Be(20);
        secondRun.RecordsAlreadyExisting.Should().Be(0);
        (await GetPageItems<AnalyticalRecordResponse>("/api/analytical-records")).Should().HaveCount(20);
    }

    [Fact]
    public async Task Reset_pipeline_rolls_back_when_a_delete_fails()
    {
        await client.PostAsync("/api/pipeline/run", null);
        await using (var analytics = CreateAnalyticsContext())
        {
            await analytics.Database.ExecuteSqlRawAsync("""
                CREATE OR ALTER TRIGGER dbo.ResetTestFailure
                ON dbo.StgTransaction
                AFTER DELETE
                AS
                BEGIN
                    THROW 51000, 'Reset test failure', 1;
                END
                """);
        }

        try
        {
            var resetResponse = await client.DeleteAsync("/api/pipeline/reset");
            resetResponse.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }
        finally
        {
            await using var analytics = CreateAnalyticsContext();
            await analytics.Database.ExecuteSqlRawAsync("DROP TRIGGER dbo.ResetTestFailure");
        }

        await using var verification = CreateAnalyticsContext();
        (await verification.FactGl.CountAsync()).Should().Be(20);
        (await verification.StgTransactions.CountAsync()).Should().Be(20);
        (await verification.PipelineRuns.CountAsync()).Should().Be(1);
    }

    [Fact]
    public async Task Unknown_pipeline_run_returns_not_found_for_all_run_endpoints()
    {
        foreach (var suffix in new[] { "", "/staging", "/transformations", "/validation" })
        {
            var response = await client.GetAsync($"/api/pipeline/runs/999999{suffix}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }

    [Fact]
    public async Task Financial_report_calculates_q1_values_from_database()
    {
        var runResponse = await client.PostAsync("/api/pipeline/run", null);
        runResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var report = await client.GetFromJsonAsync<FinancialReportResponse>(
            "/api/reports/financial?from=2026-01-01&to=2026-03-31");

        report.Should().NotBeNull();
        report!.Period.From.Should().Be(new DateOnly(2026, 1, 1));
        report.Period.To.Should().Be(new DateOnly(2026, 3, 31));
        report.Entity.Should().BeNull();
        report.CurrencyCode.Should().BeNull();
        report.Revenue.Total.Should().Be(74000m);
        report.Revenue.Lines.Should().Contain(x => x.Account == "Product Revenue" && x.Amount == 57000m);
        report.Revenue.Lines.Should().Contain(x => x.Account == "Service Revenue" && x.Amount == 17000m);
        report.Cogs.Total.Should().Be(23000m);
        report.GrossProfit.Should().Be(74000m - 23000m);
        report.GrossMargin.Should().BeApproximately((74000m - 23000m) / 74000m, 0.0001m);
        report.OperatingExpenses.Total.Should().Be(7000m);
        report.NetIncome.Should().Be(44000m);

        var canadianReport = await client.GetFromJsonAsync<FinancialReportResponse>(
            "/api/reports/financial?from=2026-01-01&to=2026-03-31&entity=CA");

        canadianReport.Should().NotBeNull();
        canadianReport!.Entity.Should().Be("CA");
        canadianReport.CurrencyCode.Should().Be("CAD");
        canadianReport.Revenue.Total.Should().BeGreaterThan(0m);
    }

    [Fact]
    public async Task Financial_report_rejects_invalid_date_range()
    {
        var response = await client.GetAsync("/api/reports/financial?from=2026-03-31&to=2026-01-01");

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task List_endpoints_return_requested_pages_and_total_counts()
    {
        await using (var fakeErp = CreateFakeErpContext())
            await TestDatabaseSeed.UseFullFakeErpAsync(fakeErp);

        var source = await client.GetFromJsonAsync<PagedResponse<SourceTransactionResponse>>(
            "/api/source/transactions?page=2&pageSize=5");

        source.Should().NotBeNull();
        source!.Items.Should().HaveCount(5);
        source.Page.Should().Be(2);
        source.TotalCount.Should().Be(10_000);
        source.TotalPages.Should().Be(2_000);

        var runResponse = await client.PostAsync("/api/pipeline/run", null);
        var run = await runResponse.Content.ReadFromJsonAsync<PipelineRunResponse>();

        var staging = await client.GetFromJsonAsync<PagedResponse<StagingTransactionResponse>>(
            $"/api/pipeline/runs/{run!.PipelineRunId}/staging?page=2&pageSize=5");
        var transformations = await client.GetFromJsonAsync<PagedResponse<PipelineTransformationResponse>>(
            $"/api/pipeline/runs/{run.PipelineRunId}/transformations?page=2&pageSize=5");
        var analytical = await client.GetFromJsonAsync<PagedResponse<AnalyticalRecordResponse>>(
            "/api/analytical-records?page=2&pageSize=5");

        staging!.Items.Should().HaveCount(5);
        staging.TotalCount.Should().Be(10_000);
        transformations!.Items.Should().HaveCount(5);
        transformations.TotalCount.Should().Be(10_000);
        analytical!.Items.Should().HaveCount(5);
        analytical.TotalCount.Should().Be(10_000);
    }

    private async Task<List<T>> GetPageItems<T>(string requestUri) =>
        (await client.GetFromJsonAsync<PagedResponse<T>>(requestUri))?.Items.ToList() ?? [];

    private FakeErpDbContext CreateFakeErpContext() => new(
        new DbContextOptionsBuilder<FakeErpDbContext>()
            .UseSqlServer(GetDatabaseConnectionString("FakeErp_Test"))
            .Options);

    private FinancialAnalyticsDbContext CreateAnalyticsContext() => new(
        new DbContextOptionsBuilder<FinancialAnalyticsDbContext>()
            .UseSqlServer(GetDatabaseConnectionString("FinancialAnalytics_Test"))
            .Options);

    private string GetDatabaseConnectionString(string databaseName)
    {
        var connectionString = new SqlConnectionStringBuilder(sqlServer.GetConnectionString())
        {
            InitialCatalog = databaseName
        };
        return connectionString.ConnectionString;
    }

    private static async Task ClearAnalyticsAsync(FinancialAnalyticsDbContext analytics)
    {
        analytics.FactGl.RemoveRange(await analytics.FactGl.ToListAsync());
        analytics.StgTransactions.RemoveRange(await analytics.StgTransactions.ToListAsync());
        analytics.PipelineRuns.RemoveRange(await analytics.PipelineRuns.ToListAsync());
        await analytics.SaveChangesAsync();
    }
}
