using Microsoft.EntityFrameworkCore;

namespace FinancialAnalytics.Api.Tests;

internal static class TestDatabaseSeed
{
    private const int ReducedTransactionCount = 20;
    private static readonly DateTime FullSeedStart = new(2026, 4, 1, 12, 0, 0, DateTimeKind.Utc);

    public static Task UseReducedFakeErpAsync(FakeErpDbContext db) =>
        db.Transactions
            .Where(transaction => transaction.CreatedAt >= FullSeedStart.AddMinutes(ReducedTransactionCount))
            .ExecuteDeleteAsync();

    public static async Task UseFullFakeErpAsync(FakeErpDbContext db)
    {
        var existingIds = await db.Transactions
            .Select(transaction => transaction.TransactionId)
            .ToListAsync();
        var missingTransactions = SeedData.ErpTransactions
            .Where(transaction => existingIds.Contains(transaction.TransactionId) is false)
            .ToArray();

        await db.Transactions.AddRangeAsync(missingTransactions);
        await db.SaveChangesAsync();
    }
}