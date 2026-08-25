namespace FinancialAnalytics.Api;

public sealed class FactGl
{
    public long FactGLKey { get; set; }
    public string SourceSystem { get; set; } = "";
    public string SourceTransactionId { get; set; } = "";
    public int DateKey { get; set; }
    public int AccountKey { get; set; }
    public int EntityKey { get; set; }
    public int CurrencyKey { get; set; }
    public decimal Amount { get; set; }
    public DimDate Date { get; set; } = null!;
    public DimAccount Account { get; set; } = null!;
    public DimEntity Entity { get; set; } = null!;
    public DimCurrency Currency { get; set; } = null!;
}
