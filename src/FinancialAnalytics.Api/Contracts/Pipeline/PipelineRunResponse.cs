namespace FinancialAnalytics.Api.Contracts.Pipeline;

public sealed record PipelineRunResponse(
    long PipelineRunId,
    string Status,
    DateTime StartedAt,
    DateTime? CompletedAt,
    int RecordsExtracted,
    int RecordsTransformed,
    int RecordsValidated,
    int RecordsLoaded,
    int RecordsInserted,
    int RecordsAlreadyExisting,
    int RecordsFailed,
    PipelineValidationResponse? Validation,
    IReadOnlyList<PipelineError> Errors);

public sealed record PipelineValidationResponse(
    int RecordsReceived,
    int AccountsMapped,
    int ValidDates,
    int TransformationErrors,
    int Duplicates,
    int InvalidAmounts,
    IReadOnlyList<CurrencyReconciliationResponse> ReconciliationByCurrency,
    bool ReconciliationPassed,
    bool IsValid,
    IReadOnlyList<PipelineError> Errors);

public sealed record CurrencyReconciliationResponse(
    string Currency,
    decimal SourceTotal,
    decimal TransformedTotal,
    decimal Difference);
