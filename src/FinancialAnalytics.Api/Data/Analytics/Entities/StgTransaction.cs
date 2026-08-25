namespace FinancialAnalytics.Api;

public sealed class StgTransaction
{
    public long StgTransactionId { get; set; }
    public long PipelineRunId { get; set; }
    public string SourceTransactionId { get; set; } = "";
    public DateOnly TransactionDate { get; set; }
    public string SourceAccountCode { get; set; } = "";
    public string SourceAccountName { get; set; } = "";
    public string SourceEntityCode { get; set; } = "";
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; } = "";
    public string? Description { get; set; }
    public PipelineRun PipelineRun { get; set; } = null!;
}
