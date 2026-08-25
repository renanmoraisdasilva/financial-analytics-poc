namespace FinancialAnalytics.Api;

public sealed class DimCurrency
{
    public int CurrencyKey { get; set; }
    public string CurrencyCode { get; set; } = "";
    public string CurrencyName { get; set; } = "";
    public ICollection<FactGl> Facts { get; set; } = [];
}
