namespace FinancialAnalytics.Api.Contracts.Reports;

public sealed record FinancialReportLineResponse(string AccountCode, string Account, decimal Amount);
