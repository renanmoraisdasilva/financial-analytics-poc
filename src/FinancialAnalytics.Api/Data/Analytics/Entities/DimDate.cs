namespace FinancialAnalytics.Api;

public sealed class DimDate
{
    public int DateKey { get; set; }
    public DateOnly Date { get; set; }
    public byte Day { get; set; }
    public byte Month { get; set; }
    public string MonthName { get; set; } = "";
    public byte Quarter { get; set; }
    public short Year { get; set; }
    public ICollection<FactGl> Facts { get; set; } = [];
}
