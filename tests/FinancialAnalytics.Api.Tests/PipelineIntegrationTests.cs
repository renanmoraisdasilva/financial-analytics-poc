using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging.Abstractions;
using Testcontainers.MsSql;
using Xunit;

namespace FinancialAnalytics.Api.Tests;

public sealed class PipelineIntegrationTests : IAsyncLifetime
{
    private readonly MsSqlContainer sqlServer = new MsSqlBuilder()
        .WithPassword(TestDatabaseSeed.SqlServerPassword)
        .Build();

    public async Task InitializeAsync()
    {
        await sqlServer.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await sqlServer.DisposeAsync();
    }

    [Fact]
    public async Task Pipeline_runs_end_to_end_against_sql_server()
    {
        await InitializeDatabasesAsync();

        await using var fakeErpDb = CreateFakeErpContext();
        await TestDatabaseSeed.UseFullFakeErpAsync(fakeErpDb);
        await using var analyticsDb = CreateAnalyticsContext();
        var pipeline = new PipelineService(
            analyticsDb,
            new ErpExtractor(fakeErpDb),
            new DataTransformer(analyticsDb),
            new DataValidator(),
            new DataLoader(analyticsDb),
            NullLogger<PipelineService>.Instance);

        var execution = await pipeline.RunAsync();
        var run = await analyticsDb.PipelineRuns.SingleAsync(x => x.PipelineRunId == execution.Run.PipelineRunId);
        var staged = await analyticsDb.StgTransactions
            .Where(x => x.PipelineRunId == run.PipelineRunId)
            .ToListAsync();
        var facts = await analyticsDb.FactGl.ToListAsync();
        var sourceTransactions = await fakeErpDb.Transactions.AsNoTracking().ToListAsync();

        sourceTransactions.Should().HaveCount(10_000);
        sourceTransactions.Where(x => x.EntityId == 1).Should().OnlyContain(x => x.CurrencyCode == "USD");
        sourceTransactions.Where(x => x.EntityId == 2).Should().OnlyContain(x => x.CurrencyCode == "CAD");
        sourceTransactions.Should().Contain(x => x.EntityId == 1);
        sourceTransactions.Should().Contain(x => x.EntityId == 2);
        sourceTransactions.Should().OnlyContain(x => x.TransactionDate >= new DateOnly(2025, 1, 1) && x.TransactionDate <= new DateOnly(2026, 12, 31));

        run.Status.Should().Be("Completed");
        run.RecordsExtracted.Should().Be(10_000);
        run.RecordsTransformed.Should().Be(10_000);
        run.RecordsValidated.Should().Be(10_000);
        run.RecordsLoaded.Should().Be(10_000);
        run.RecordsInserted.Should().Be(10_000);
        run.RecordsAlreadyExisting.Should().Be(0);
        run.RecordsFailed.Should().Be(0);
        staged.Should().HaveCount(10_000);
        facts.Should().HaveCount(10_000);
        facts.Select(x => x.SourceTransactionId).Should().OnlyHaveUniqueItems();
        facts.Sum(x => x.Amount).Should().Be(sourceTransactions.Sum(x => x.Amount));

        var secondExecution = await pipeline.RunAsync();
        secondExecution.Run.RecordsLoaded.Should().Be(10_000);
        secondExecution.Run.RecordsInserted.Should().Be(0);
        secondExecution.Run.RecordsAlreadyExisting.Should().Be(10_000);
        (await analyticsDb.FactGl.ToListAsync()).Should().HaveCount(10_000);

        var accountTotals = await analyticsDb.FactGl
            .Join(analyticsDb.DimAccounts, fact => fact.AccountKey, account => account.AccountKey, (fact, account) => new { account.AccountCode, account.AccountName, account.AccountCategory, fact.Amount })
            .GroupBy(x => new { x.AccountCode, x.AccountName, x.AccountCategory })
            .Select(group => new { group.Key.AccountCode, group.Key.AccountName, group.Key.AccountCategory, Amount = group.Sum(x => x.Amount) })
            .ToDictionaryAsync(x => x.AccountCode);

        accountTotals["REV-PROD"].AccountName.Should().Be("Product Revenue");
        accountTotals["REV-SERV"].AccountName.Should().Be("Service Revenue");
        accountTotals["COGS-MAT"].AccountName.Should().Be("Materials");
        accountTotals["OPEX-SAL"].AccountName.Should().Be("Salaries");
        accountTotals["REV-PROD"].Amount.Should().Be(31_219_550m);
        accountTotals["REV-SERV"].Amount.Should().Be(9_098_800m);
        accountTotals["COGS-MAT"].Amount.Should().Be(-12_772_450m);
        accountTotals["OPEX-SAL"].Amount.Should().Be(-3_949_100m);

        var revenue = accountTotals.Values.Where(x => x.AccountCategory == "Revenue").Sum(x => x.Amount);
        var cogs = -accountTotals.Values.Where(x => x.AccountCategory == "COGS").Sum(x => x.Amount);
        var operatingExpenses = -accountTotals.Values.Where(x => x.AccountCategory == "Operating Expense").Sum(x => x.Amount);
        var grossProfit = revenue - cogs;
        var netIncome = grossProfit - operatingExpenses;

        revenue.Should().Be(40_318_350m);
        cogs.Should().Be(12_772_450m);
        grossProfit.Should().Be(27_545_900m);
        operatingExpenses.Should().Be(3_949_100m);
        netIncome.Should().Be(23_596_800m);
    }

    [Fact]
    public async Task Pipeline_fails_validation_without_loading_facts()
    {
        await InitializeDatabasesAsync();

        await using (var fakeErpDb = CreateFakeErpContext())
        {
            var transaction = await fakeErpDb.Transactions.FirstAsync();
            transaction.Amount = 0m;
            await fakeErpDb.SaveChangesAsync();
        }

        await using var fakeErp = CreateFakeErpContext();
        await using var analytics = CreateAnalyticsContext();
        var pipeline = new PipelineService(
            analytics,
            new ErpExtractor(fakeErp),
            new DataTransformer(analytics),
            new DataValidator(),
            new DataLoader(analytics),
            NullLogger<PipelineService>.Instance);

        var execution = await pipeline.RunAsync();
        var run = await analytics.PipelineRuns.SingleAsync(x => x.PipelineRunId == execution.Run.PipelineRunId);
        var facts = await analytics.FactGl.ToListAsync();

        run.Status.Should().Be("Failed");
        run.RecordsLoaded.Should().Be(0);
        run.RecordsFailed.Should().BeGreaterThan(0);
        execution.Validation.Should().NotBeNull();
        execution.Validation!.IsValid.Should().BeFalse();
        execution.Validation.InvalidAmounts.Should().Be(1);
        facts.Should().BeEmpty();
    }

    [Fact]
    public async Task Pipeline_reports_all_transformation_errors_without_loading_facts()
    {
        await InitializeDatabasesAsync();

        await using (var fakeErpDb = CreateFakeErpContext())
        {
            var account = await fakeErpDb.Accounts.SingleAsync(x => x.AccountCode == "4000");
            account.AccountCode = "9999";
            await fakeErpDb.SaveChangesAsync();
        }

        await using var fakeErp = CreateFakeErpContext();
        await using var analytics = CreateAnalyticsContext();
        var pipeline = new PipelineService(
            analytics,
            new ErpExtractor(fakeErp),
            new DataTransformer(analytics),
            new DataValidator(),
            new DataLoader(analytics),
            NullLogger<PipelineService>.Instance);

        var execution = await pipeline.RunAsync();
        var run = await analytics.PipelineRuns.SingleAsync(x => x.PipelineRunId == execution.Run.PipelineRunId);
        var facts = await analytics.FactGl.ToListAsync();

        execution.Validation.Should().BeNull();
        var transformationErrors = execution.Errors
            .Where(error => error.Phase == "Transform")
            .ToList();
        run.Status.Should().Be("Failed");
        transformationErrors.Should().NotBeEmpty();
        run.RecordsTransformed.Should().Be(run.RecordsExtracted - transformationErrors.Count);
        run.RecordsValidated.Should().Be(0);
        run.RecordsLoaded.Should().Be(0);
        facts.Should().BeEmpty();
        transformationErrors.Should().OnlyContain(error =>
            error.Code == "UnknownAccount"
            && error.SourceTransactionId != null
            && error.Message.Contains("9999"));
    }

    [Fact]
    public async Task Transform_failure_scenario_skips_validation_and_load()
    {
        await InitializeDatabasesAsync();

        await using var fakeErp = CreateFakeErpContext();
        await using var analytics = CreateAnalyticsContext();
        var pipeline = new PipelineService(
            analytics,
            new ErpExtractor(fakeErp),
            new DataTransformer(analytics),
            new DataValidator(),
            new DataLoader(analytics),
            NullLogger<PipelineService>.Instance);

        var execution = await pipeline.RunAsync(PipelineScenarios.TransformFailure);
        var run = await analytics.PipelineRuns.SingleAsync();

        run.Status.Should().Be("Failed");
        run.RecordsExtracted.Should().Be(20);
        run.RecordsTransformed.Should().Be(19);
        run.RecordsValidated.Should().Be(0);
        run.RecordsLoaded.Should().Be(0);
        execution.Validation.Should().BeNull();
        execution.Errors.Should().ContainSingle(error =>
            error.Phase == "Transform"
            && error.Code == "MissingDateDimension"
            && error.SourceTransactionId == "A005");
        (await analytics.FactGl.CountAsync()).Should().Be(0);
    }

    [Fact]
    public async Task Validation_failure_scenario_reports_currency_mismatch_without_loading_facts()
    {
        await InitializeDatabasesAsync();

        await using var fakeErp = CreateFakeErpContext();
        await using var analytics = CreateAnalyticsContext();
        var pipeline = new PipelineService(
            analytics,
            new ErpExtractor(fakeErp),
            new DataTransformer(analytics),
            new DataValidator(),
            new DataLoader(analytics),
            NullLogger<PipelineService>.Instance);

        var execution = await pipeline.RunAsync(PipelineScenarios.ValidationFailure);
        var run = await analytics.PipelineRuns.SingleAsync();

        run.Status.Should().Be("Failed");
        run.RecordsExtracted.Should().Be(20);
        run.RecordsTransformed.Should().Be(20);
        run.RecordsValidated.Should().Be(20);
        run.RecordsLoaded.Should().Be(0);
        execution.Validation.Should().NotBeNull();
        execution.Validation!.Duplicates.Should().Be(0);
        execution.Validation.ReconciliationPassed.Should().BeFalse();
        execution.Validation.ReconciliationByCurrency.Should().ContainSingle(item =>
            item.Currency == "CAD" && item.Difference == -10000m);
        execution.Validation.Errors.Should().Contain(error =>
            error.Phase == "Validate"
            && error.Code == "ReconciliationMismatch"
            && error.Message.Contains("CAD"));
        (await analytics.FactGl.CountAsync()).Should().Be(0);
    }

    private async Task InitializeDatabasesAsync()
    {
        await using var fakeErp = CreateFakeErpContext();
        await using var analytics = CreateAnalyticsContext();
        await fakeErp.Database.MigrateAsync();
        await analytics.Database.MigrateAsync();
        await TestDatabaseSeed.UseReducedFakeErpAsync(fakeErp);
        await ClearSeededAnalyticalRunAsync(analytics);
    }

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

    private static async Task ClearSeededAnalyticalRunAsync(FinancialAnalyticsDbContext analytics)
    {
        analytics.FactGl.RemoveRange(await analytics.FactGl.ToListAsync());
        analytics.StgTransactions.RemoveRange(await analytics.StgTransactions.ToListAsync());
        analytics.PipelineRuns.RemoveRange(await analytics.PipelineRuns.ToListAsync());
        await analytics.SaveChangesAsync();
    }
}
