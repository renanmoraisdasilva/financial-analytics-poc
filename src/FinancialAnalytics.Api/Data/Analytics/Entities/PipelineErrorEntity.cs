namespace FinancialAnalytics.Api;

public sealed class PipelineErrorEntity
{
    public long PipelineErrorId { get; set; }
    public long PipelineRunId { get; set; }
    public string Stage { get; set; } = "";
    public string ErrorCode { get; set; } = "";
    public string? SourceTransactionId { get; set; }
    public string Message { get; set; } = "";
    public PipelineRun PipelineRun { get; set; } = null!;
}