namespace FinancialAnalytics.Api.Contracts.Reports;

public sealed record FinancialReportResponse(
    FinancialReportPeriodResponse Period,
    string? Entity,
    string? CurrencyCode,
    FinancialReportSectionResponse Revenue,
    FinancialReportSectionResponse Cogs,
    decimal GrossProfit,
    decimal GrossMargin,
    FinancialReportSectionResponse OperatingExpenses,
    decimal NetIncome);

public sealed record FinancialReportPeriodResponse(DateOnly From, DateOnly To);

public sealed record FinancialReportSectionResponse(
    decimal Total,
    IReadOnlyList<FinancialReportLineResponse> Lines);
