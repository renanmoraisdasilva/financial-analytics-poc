namespace FinancialAnalytics.Api;

public sealed class DimAccount
{
    public int AccountKey { get; set; }
    public string AccountCode { get; set; } = "";
    public string AccountName { get; set; } = "";
    public string AccountCategory { get; set; } = "";
    public int? ParentAccountKey { get; set; }
    public DimAccount? ParentAccount { get; set; }
    public ICollection<DimAccount> ChildAccounts { get; set; } = [];
    public ICollection<FactGl> Facts { get; set; } = [];
}
