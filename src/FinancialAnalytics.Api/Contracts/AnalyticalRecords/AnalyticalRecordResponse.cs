namespace FinancialAnalytics.Api.Contracts.AnalyticalRecords;

public sealed record AnalyticalRecordResponse(
    string SourceSystem,
    string SourceTransactionId,
    DateOnly TransactionDate,
    string AccountCode,
    string AccountName,
    string AccountCategory,
    string EntityCode,
    string CurrencyCode,
    decimal Amount);