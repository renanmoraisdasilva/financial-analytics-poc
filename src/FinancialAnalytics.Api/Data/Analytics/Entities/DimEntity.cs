namespace FinancialAnalytics.Api;

public sealed class DimEntity
{
    public int EntityKey { get; set; }
    public string EntityCode { get; set; } = "";
    public string EntityName { get; set; } = "";
    public string CountryCode { get; set; } = "";
    public ICollection<FactGl> Facts { get; set; } = [];
}
