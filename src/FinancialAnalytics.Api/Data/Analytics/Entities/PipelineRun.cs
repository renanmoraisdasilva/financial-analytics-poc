namespace FinancialAnalytics.Api;

public sealed class PipelineRun
{
    public long PipelineRunId { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string Status { get; set; } = "";
    public string Scenario { get; set; } = PipelineScenarios.Happy;
    public string? ValidationResultJson { get; set; }
    public int RecordsExtracted { get; set; }
    public int RecordsTransformed { get; set; }
    public int RecordsValidated { get; set; }
    public int RecordsLoaded { get; set; }
    public int RecordsInserted { get; set; }
    public int RecordsAlreadyExisting { get; set; }
    public int RecordsFailed { get; set; }
    public ICollection<StgTransaction> StagedTransactions { get; set; } = [];
}
