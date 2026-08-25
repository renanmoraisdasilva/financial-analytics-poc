namespace FinancialAnalytics.Api.Contracts.AnalyticalRecords;

public sealed record AnalyticalRecordsPageResponse(
    IReadOnlyList<AnalyticalRecordResponse> Items,
    int Page,
    int PageSize,
    int TotalCount,
    int AccountCount,
    int EntityCount,
    int DateCount,
    int CurrencyCount)
{
    public int TotalPages => TotalCount == 0 ? 0 : (int)Math.Ceiling(TotalCount / (double)PageSize);
}