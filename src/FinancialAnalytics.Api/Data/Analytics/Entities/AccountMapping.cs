namespace FinancialAnalytics.Api;

public sealed class AccountMapping
{
    public int AccountMappingKey { get; set; }
    public string SourceSystem { get; set; } = "";
    public string SourceAccountCode { get; set; } = "";
    public int AccountKey { get; set; }
    public DimAccount Account { get; set; } = null!;
}
