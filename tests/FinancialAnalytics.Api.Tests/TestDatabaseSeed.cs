using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Testcontainers.MsSql;

namespace FinancialAnalytics.Api.Tests;

internal static class TestDatabaseSeed
{
    private const int ReducedTransactionCount = 20;
    private static readonly DateTime FullSeedStart = new(2026, 4, 1, 12, 0, 0, DateTimeKind.Utc);
    private static readonly string GeneratedSqlServerPassword = $"Aa1!{Convert.ToHexString(RandomNumberGenerator.GetBytes(16))}";

    public static string SqlServerPassword =>
        string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("MSSQL_SA_PASSWORD"))
            ? GeneratedSqlServerPassword
            : Environment.GetEnvironmentVariable("MSSQL_SA_PASSWORD")!;

    public static async Task StartSqlServerAsync(MsSqlContainer sqlServer)
    {
        try
        {
            await sqlServer.StartAsync();
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException(
                "Could not start the SQL Server test container. Integration tests require Docker Desktop or another running Docker engine.",
                exception);
        }
    }

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