namespace FinancialAnalytics.Api.Contracts.Source;

public sealed record SourceTransactionResponse(
    string SourceTransactionId,
    DateOnly TransactionDate,
    string SourceAccountCode,
    string SourceAccountName,
    string SourceEntityCode,
    decimal Amount,
    string CurrencyCode,
    string? Description);