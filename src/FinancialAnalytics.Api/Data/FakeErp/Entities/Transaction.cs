namespace FinancialAnalytics.Api;

public sealed class ErpTransaction
{
    public string TransactionId { get; set; } = "";
    public DateOnly TransactionDate { get; set; }
    public int AccountId { get; set; }
    public int EntityId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; } = "";
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public ErpAccount Account { get; set; } = null!;
    public ErpEntity Entity { get; set; } = null!;
}
