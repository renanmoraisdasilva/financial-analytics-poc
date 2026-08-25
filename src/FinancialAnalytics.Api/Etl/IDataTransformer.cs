namespace FinancialAnalytics.Api;

public interface IDataTransformer
{
    Task<TransformationResult> TransformAsync(
        IEnumerable<StgTransaction> stagedTransactions,
        CancellationToken cancellationToken = default);
}

public sealed record TransformationResult(
    IReadOnlyList<TransformedTransaction> Transactions,
    IReadOnlyList<PipelineError> Errors);

public sealed record PipelineError(
    string Phase,
    string Code,
    string? SourceTransactionId,
    string Message);

public sealed record TransformedTransaction(
    string SourceSystem,
    string SourceTransactionId,
    DateOnly TransactionDate,
    int AccountKey,
    string AccountCode,
    string AccountName,
    string AccountCategory,
    int EntityKey,
    int DateKey,
    int CurrencyKey,
    decimal Amount);
