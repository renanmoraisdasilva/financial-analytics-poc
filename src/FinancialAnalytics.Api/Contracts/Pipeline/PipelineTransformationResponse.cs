namespace FinancialAnalytics.Api.Contracts.Pipeline;

public sealed record PipelineTransformationResponse(
    string SourceTransactionId,
    DateOnly TransactionDate,
    string SourceAccountCode,
    string SourceAccountName,
    string SourceEntityCode,
    decimal Amount,
    string CurrencyCode,
    string? Description,
    string? CanonicalAccountCode,
    string? CanonicalAccountName,
    string? AccountCategory,
    int? AccountKey,
    string? EntityName,
    int? EntityKey,
    int? DateKey,
    string? CurrencyName,
    int? CurrencyKey,
    string? ErrorCode,
    string? ErrorMessage);