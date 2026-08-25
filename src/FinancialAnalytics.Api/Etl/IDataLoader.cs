namespace FinancialAnalytics.Api;

public interface IDataLoader
{
    Task<LoadResult> LoadAsync(
        IReadOnlyCollection<TransformedTransaction> transformedTransactions,
        CancellationToken cancellationToken = default);
}

public sealed record LoadResult(
    int RecordsProcessed,
    int RecordsInserted,
    int RecordsAlreadyExisting);
