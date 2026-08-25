using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FinancialAnalytics.Api.Tests;

public sealed class DataTransformerTests
{
    private static async Task<FinancialAnalyticsDbContext> CreateContext()
    {
        var context = new FinancialAnalyticsDbContext(
            new DbContextOptionsBuilder<FinancialAnalyticsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
        await context.Database.EnsureCreatedAsync();
        return context;
    }

    [Theory]
    [InlineData("4000", "REV-PROD", "Product Revenue")]
    [InlineData("4010", "REV-SERV", "Service Revenue")]
    [InlineData("5000", "COGS-MAT", "Materials")]
    [InlineData("6000", "OPEX-SAL", "Salaries")]
    public async Task Source_account_transforms_to_canonical_account(string sourceCode, string canonicalCode, string canonicalName)
    {
        await using var db = await CreateContext();
        var source = TestFixtures.StagedTransactions.First(transaction => transaction.SourceAccountCode == sourceCode);

        var transformed = (await new DataTransformer(db).TransformAsync([source])).Transactions.Single();

        transformed.AccountCode.Should().Be(canonicalCode);
        transformed.AccountName.Should().Be(canonicalName);
    }

    [Fact]
    public async Task Unknown_account_is_returned_as_a_structured_transformation_error()
    {
        await using var db = await CreateContext();
        var source = Copy(TestFixtures.StagedTransactions[0], sourceAccountCode: "9999");

        var result = await new DataTransformer(db).TransformAsync([source]);

        result.Transactions.Should().BeEmpty();
        result.Errors.Should().ContainSingle(error =>
            error.Phase == "Transform"
            && error.Code == "UnknownAccount"
            && error.SourceTransactionId == source.SourceTransactionId
            && error.Message.Contains("9999"));
    }

    [Fact]
    public async Task Transformation_continues_after_bad_records_and_reports_all_errors()
    {
        await using var db = await CreateContext();
        var valid = TestFixtures.StagedTransactions[0];
        var unknownAccount = Copy(TestFixtures.StagedTransactions[1], sourceAccountCode: "9999");
        var missingDate = Copy(TestFixtures.StagedTransactions[2], transactionDate: new DateOnly(2024, 12, 31));

        var result = await new DataTransformer(db).TransformAsync([valid, unknownAccount, missingDate]);

        result.Transactions.Should().ContainSingle(x => x.SourceTransactionId == valid.SourceTransactionId);
        result.Errors.Should().HaveCount(2);
        result.Errors.Should().Contain(error => error.Code == "UnknownAccount" && error.SourceTransactionId == unknownAccount.SourceTransactionId);
        result.Errors.Should().Contain(error => error.Code == "MissingDateDimension" && error.SourceTransactionId == missingDate.SourceTransactionId);
    }

    private static StgTransaction Copy(
        StgTransaction source,
        string? sourceAccountCode = null,
        decimal? amount = null,
        DateOnly? transactionDate = null) => new()
    {
        StgTransactionId = source.StgTransactionId,
        PipelineRunId = source.PipelineRunId,
        SourceTransactionId = source.SourceTransactionId,
        TransactionDate = transactionDate ?? source.TransactionDate,
        SourceAccountCode = sourceAccountCode ?? source.SourceAccountCode,
        SourceAccountName = source.SourceAccountName,
        SourceEntityCode = source.SourceEntityCode,
        Amount = amount ?? source.Amount,
        CurrencyCode = source.CurrencyCode,
        Description = source.Description
    };
}

public sealed class DataValidatorTests
{
    private static async Task<FinancialAnalyticsDbContext> CreateContext()
    {
        var context = new FinancialAnalyticsDbContext(
            new DbContextOptionsBuilder<FinancialAnalyticsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
        await context.Database.EnsureCreatedAsync();
        return context;
    }

    [Fact]
    public async Task Valid_records_reconcile()
    {
        await using var db = await CreateContext();
        var staged = TestFixtures.StagedTransactions;
        var transformation = await new DataTransformer(db).TransformAsync(staged);

        var result = new DataValidator().Validate(staged, transformation);

        result.IsValid.Should().BeTrue();
        result.RecordsReceived.Should().Be(10_000);
        result.AccountsMapped.Should().Be(10_000);
        result.ValidDates.Should().Be(10_000);
        result.ReconciliationByCurrency.Should().BeEquivalentTo([
            new CurrencyReconciliation("CAD", 8049900m, 8049900m, 0m),
            new CurrencyReconciliation("USD", 15546900m, 15546900m, 0m)
        ]);
        result.ReconciliationPassed.Should().BeTrue();
    }

    [Fact]
    public async Task Duplicate_source_transaction_fails_validation()
    {
        await using var db = await CreateContext();
        var staged = new[] { TestFixtures.StagedTransactions[0], TestFixtures.StagedTransactions[0] };
        var transformation = await new DataTransformer(db).TransformAsync(staged);

        var result = new DataValidator().Validate(staged, transformation);

        result.IsValid.Should().BeFalse();
        result.Duplicates.Should().Be(1);
        result.Errors.Should().Contain(error => error.Message.Contains("duplicate", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task Zero_amount_fails_validation()
    {
        await using var db = await CreateContext();
        var staged = new[] { Copy(TestFixtures.StagedTransactions[0], amount: 0m) };
        var transformation = await new DataTransformer(db).TransformAsync(staged);

        var result = new DataValidator().Validate(staged, transformation);

        result.IsValid.Should().BeFalse();
        result.InvalidAmounts.Should().Be(1);
    }

    [Fact]
    public async Task Mismatched_totals_fail_validation()
    {
        await using var db = await CreateContext();
        var staged = new[] { TestFixtures.StagedTransactions[0] };
        var transformation = await new DataTransformer(db).TransformAsync(staged);
        transformation = transformation with
        {
            Transactions = transformation.Transactions
                .Select(transaction => transaction with { Amount = transaction.Amount + 1m })
                .ToArray()
        };

        var result = new DataValidator().Validate(staged, transformation);

        result.IsValid.Should().BeFalse();
        result.ReconciliationPassed.Should().BeFalse();
        result.ReconciliationByCurrency.Should().ContainSingle(item =>
            item.Currency == "USD" && item.SourceTotal == staged[0].Amount
            && item.TransformedTotal == staged[0].Amount + 1m && item.Difference == -1m);
        result.Errors.Should().Contain(error => error.Message.Contains("reconcile", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task USD_and_CAD_reconcile_independently_without_combining_totals()
    {
        await using var db = await CreateContext();
        var staged = new[]
        {
            Copy(TestFixtures.StagedTransactions[0], amount: 100m, currencyCode: "USD"),
            Copy(TestFixtures.StagedTransactions[1], amount: 200m, currencyCode: "CAD")
        };
        var transformation = await new DataTransformer(db).TransformAsync(staged);

        var result = new DataValidator().Validate(staged, transformation);

        result.ReconciliationPassed.Should().BeTrue();
        result.ReconciliationByCurrency.Should().BeEquivalentTo([
            new CurrencyReconciliation("CAD", 200m, 200m, 0m),
            new CurrencyReconciliation("USD", 100m, 100m, 0m)
        ]);
    }

    [Theory]
    [InlineData("USD", 0)]
    [InlineData("CAD", 1)]
    public async Task Mismatch_in_one_currency_fails_only_that_currency(string currencyCode, int fixtureIndex)
    {
        await using var db = await CreateContext();
        var staged = new[] { Copy(TestFixtures.StagedTransactions[fixtureIndex], currencyCode: currencyCode) };
        var transformation = await new DataTransformer(db).TransformAsync(staged);
        transformation = transformation with
        {
            Transactions = transformation.Transactions
                .Select(transaction => transaction with { Amount = transaction.Amount + 100m })
                .ToArray()
        };

        var result = new DataValidator().Validate(staged, transformation);

        result.ReconciliationPassed.Should().BeFalse();
        result.ReconciliationByCurrency.Should().ContainSingle(item =>
            item.Currency == currencyCode && item.Difference == -100m);
        result.Errors.Should().Contain(error =>
            error.Code == "ReconciliationMismatch" && error.Message.Contains(currencyCode));
    }

    private static StgTransaction Copy(StgTransaction source, decimal? amount = null, string? currencyCode = null) => new()
    {
        StgTransactionId = source.StgTransactionId,
        PipelineRunId = source.PipelineRunId,
        SourceTransactionId = source.SourceTransactionId,
        TransactionDate = source.TransactionDate,
        SourceAccountCode = source.SourceAccountCode,
        SourceAccountName = source.SourceAccountName,
        SourceEntityCode = source.SourceEntityCode,
        Amount = amount ?? source.Amount,
        CurrencyCode = currencyCode ?? source.CurrencyCode,
        Description = source.Description
    };
}

internal static class TestFixtures
{
    public static readonly StgTransaction[] StagedTransactions = SeedData.ErpTransactions.Select((transaction, index) => new StgTransaction
    {
        StgTransactionId = index + 1,
        PipelineRunId = 1,
        SourceTransactionId = transaction.TransactionId,
        TransactionDate = transaction.TransactionDate,
        SourceAccountCode = SeedData.ErpAccounts.Single(account => account.AccountId == transaction.AccountId).AccountCode,
        SourceAccountName = SeedData.ErpAccounts.Single(account => account.AccountId == transaction.AccountId).AccountName,
        SourceEntityCode = "US",
        Amount = transaction.Amount,
        CurrencyCode = transaction.CurrencyCode,
        Description = transaction.Description
    }).ToArray();
}
