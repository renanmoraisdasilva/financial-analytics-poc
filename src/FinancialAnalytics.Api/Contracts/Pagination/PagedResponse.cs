namespace FinancialAnalytics.Api.Contracts.Pagination;

public sealed record PagedResponse<T>(
    IReadOnlyList<T> Items,
    int Page,
    int PageSize,
    int TotalCount)
{
    public int TotalPages => TotalCount == 0 ? 0 : (int)Math.Ceiling(TotalCount / (double)PageSize);
}

public static class Pagination
{
    public const int DefaultPage = 1;
    public const int DefaultPageSize = 25;
    public const int MaxPageSize = 100;

    public static bool IsValid(int page, int pageSize) =>
        page >= 1 && pageSize >= 1 && pageSize <= MaxPageSize;
}