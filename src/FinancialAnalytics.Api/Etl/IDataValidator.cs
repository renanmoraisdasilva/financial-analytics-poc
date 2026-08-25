namespace FinancialAnalytics.Api;

public interface IDataValidator
{
    ValidationResult Validate(
        IReadOnlyCollection<StgTransaction> stagedTransactions,
        TransformationResult transformation);
}

public sealed record ValidationResult(
    int RecordsReceived,
    int AccountsMapped,
    int ValidDates,
    int TransformationErrors,
    int Duplicates,
    int InvalidAmounts,
    IReadOnlyList<CurrencyReconciliation> ReconciliationByCurrency,
    bool ReconciliationPassed,
    bool IsValid,
    IReadOnlyList<PipelineError> Errors);

public sealed record CurrencyReconciliation(
    string Currency,
    decimal SourceTotal,
    decimal TransformedTotal,
    decimal Difference);
