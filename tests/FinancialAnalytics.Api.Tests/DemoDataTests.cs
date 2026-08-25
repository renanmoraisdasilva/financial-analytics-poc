using FluentAssertions;
using Xunit;

namespace FinancialAnalytics.Api.Tests;

public sealed class FoundationSeedTests
{
    [Fact]
    public void Seed_contains_expected_erp_records_and_totals()
    {
        SeedData.ErpAccounts.Should().HaveCount(4);
        SeedData.ErpEntities.Should().HaveCount(2);
        SeedData.ErpTransactions.Should().HaveCount(10_000);
        SeedData.ErpTransactions.Select(x => x.TransactionId).Should().OnlyHaveUniqueItems();
        SeedData.ErpTransactions.Should().OnlyContain(x => x.AccountId >= 1 && x.AccountId <= 4);
        SeedData.ErpTransactions.Where(x => x.EntityId == 1).Should().OnlyContain(x => x.CurrencyCode == "USD");
        SeedData.ErpTransactions.Where(x => x.EntityId == 2).Should().OnlyContain(x => x.CurrencyCode == "CAD");
        SeedData.ErpTransactions.Should().Contain(x => x.EntityId == 1);
        SeedData.ErpTransactions.Should().Contain(x => x.EntityId == 2);
        SeedData.ErpTransactions.Where(x => x.AccountId == 1 || x.AccountId == 2).Should().OnlyContain(x => x.Amount > 0);
        SeedData.ErpTransactions.Where(x => x.AccountId == 3 || x.AccountId == 4).Should().OnlyContain(x => x.Amount < 0);
    }

    [Fact]
    public void Seed_contains_full_2025_and_2026_date_dimension_and_analytical_dimensions()
    {
        SeedData.DimAccounts.Should().HaveCount(4);
        SeedData.DimEntities.Should().HaveCount(2);
        SeedData.DimEntities.Should().Contain(x => x.EntityKey == 1 && x.EntityCode == "US");
        SeedData.DimEntities.Should().Contain(x => x.EntityKey == 2 && x.EntityCode == "CA");
        SeedData.DimCurrencies.Should().HaveCount(2);
        SeedData.DimCurrencies.Should().Contain(x => x.CurrencyKey == 1 && x.CurrencyCode == "USD");
        SeedData.DimCurrencies.Should().Contain(x => x.CurrencyKey == 2 && x.CurrencyCode == "CAD");
        SeedData.DimDates.Should().HaveCount(730);
        SeedData.DimDates.Min(x => x.Date).Should().Be(new DateOnly(2025, 1, 1));
        SeedData.DimDates.Max(x => x.Date).Should().Be(new DateOnly(2026, 12, 31));
        SeedData.DimDates.Select(x => x.Date).Should().OnlyHaveUniqueItems();
        SeedData.DimDates.Should().Contain(x => x.Date == new DateOnly(2026, 2, 28));
        SeedData.DimDates.Should().Contain(x => x.Date == new DateOnly(2026, 12, 31));
    }
}
