using Microsoft.EntityFrameworkCore;

namespace FinancialAnalytics.Api;

public sealed class DataLoader(FinancialAnalyticsDbContext db) : IDataLoader
{
    public async Task<LoadResult> LoadAsync(
        IReadOnlyCollection<TransformedTransaction> transformedTransactions,
        CancellationToken cancellationToken = default)
    {
        var sourceSystems = transformedTransactions
            .Select(item => item.SourceSystem)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();
        var sourceIds = transformedTransactions
            .Select(item => item.SourceTransactionId)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();
        var existingSourceKeys = await db.FactGl
            .Where(fact => sourceSystems.Contains(fact.SourceSystem)
                && sourceIds.Contains(fact.SourceTransactionId))
            .Select(fact => new { fact.SourceSystem, fact.SourceTransactionId })
            .ToListAsync(cancellationToken);
        var existing = existingSourceKeys
            .Select(item => ToSourceKey(item.SourceSystem, item.SourceTransactionId))
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
        var recordsProcessed = transformedTransactions.Count;
        var recordsAlreadyExisting = transformedTransactions.Count(
            item => existing.Contains(ToSourceKey(item.SourceSystem, item.SourceTransactionId)));
        var facts = transformedTransactions
            .Where(item => existing.Contains(ToSourceKey(item.SourceSystem, item.SourceTransactionId)) is false)
            .Select(item => new FactGl
            {
                SourceSystem = item.SourceSystem,
                SourceTransactionId = item.SourceTransactionId,
                DateKey = item.DateKey,
                AccountKey = item.AccountKey,
                EntityKey = item.EntityKey,
                CurrencyKey = item.CurrencyKey,
                Amount = item.Amount
            })
            .ToList();

        await db.FactGl.AddRangeAsync(facts, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
        return new LoadResult(recordsProcessed, facts.Count, recordsAlreadyExisting);
    }

    private static string ToSourceKey(string sourceSystem, string sourceTransactionId) =>
        $"{sourceSystem}\0{sourceTransactionId}";
}
