namespace FinancialAnalytics.Api.Contracts.Staging;

public sealed record StagingTransactionResponse(
    long PipelineRunId,
    string SourceTransactionId,
    DateOnly TransactionDate,
    string SourceAccountCode,
    string SourceAccountName,
    string SourceEntityCode,
    decimal Amount,
    string CurrencyCode,
    string? Description);