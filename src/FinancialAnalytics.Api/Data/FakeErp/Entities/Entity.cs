namespace FinancialAnalytics.Api;

public sealed class ErpEntity
{
    public int EntityId { get; set; }
    public string EntityCode { get; set; } = "";
    public string EntityName { get; set; } = "";
    public string CountryCode { get; set; } = "";
    public ICollection<ErpTransaction> Transactions { get; set; } = [];
}
