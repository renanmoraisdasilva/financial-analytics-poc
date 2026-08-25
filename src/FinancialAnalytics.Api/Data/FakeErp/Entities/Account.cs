namespace FinancialAnalytics.Api;

public sealed class ErpAccount
{
    public int AccountId { get; set; }
    public string AccountCode { get; set; } = "";
    public string AccountName { get; set; } = "";
    public ICollection<ErpTransaction> Transactions { get; set; } = [];
}
