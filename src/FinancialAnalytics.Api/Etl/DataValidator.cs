namespace FinancialAnalytics.Api;

public sealed class DataValidator : IDataValidator
{
    public ValidationResult Validate(
        IReadOnlyCollection<StgTransaction> stagedTransactions,
        TransformationResult transformation)
    {
        var transformedTransactions = transformation.Transactions;
        var errors = transformation.Errors.ToList();
        var duplicateIdCount = stagedTransactions
            .GroupBy(transaction => transaction.SourceTransactionId, StringComparer.OrdinalIgnoreCase)
            .Where(group => !string.IsNullOrWhiteSpace(group.Key) && group.Count() > 1)
            .Sum(group => group.Count() - 1);
        var invalidAmounts = stagedTransactions.Count(transaction => transaction.Amount == 0m);
        var missingIds = stagedTransactions.Count(transaction => string.IsNullOrWhiteSpace(transaction.SourceTransactionId));
        var sourceCurrencyById = stagedTransactions
            .GroupBy(transaction => transaction.SourceTransactionId, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.First().CurrencyCode, StringComparer.OrdinalIgnoreCase);
        var sourceTotals = stagedTransactions
            .GroupBy(transaction => transaction.CurrencyCode, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.Sum(transaction => transaction.Amount), StringComparer.OrdinalIgnoreCase);
        var transformedTotals = transformedTransactions
            .GroupBy(transaction => sourceCurrencyById.TryGetValue(transaction.SourceTransactionId, out var currency)
                ? currency
                : $"CurrencyKey:{transaction.CurrencyKey}", StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.Sum(transaction => transaction.Amount), StringComparer.OrdinalIgnoreCase);
        var reconciliationByCurrency = sourceTotals.Keys
            .Union(transformedTotals.Keys, StringComparer.OrdinalIgnoreCase)
            .OrderBy(currency => currency)
            .Select(currency =>
            {
                sourceTotals.TryGetValue(currency, out var sourceTotal);
                transformedTotals.TryGetValue(currency, out var transformedTotal);
                return new CurrencyReconciliation(currency, sourceTotal, transformedTotal, sourceTotal - transformedTotal);
            })
            .ToList();
        var reconciliationPassed = reconciliationByCurrency.All(item => item.Difference == 0m);

        if (missingIds > 0)
            errors.Add(new PipelineError("Validate", "MissingSourceTransactionId", null, $"{missingIds} source transaction IDs are missing."));
        if (duplicateIdCount > 0)
            errors.Add(new PipelineError("Validate", "DuplicateSourceTransactionId", null, $"{duplicateIdCount} duplicate source transaction IDs were found."));
        if (invalidAmounts > 0)
            errors.Add(new PipelineError("Validate", "InvalidAmount", null, $"{invalidAmounts} transaction amounts are invalid."));
        foreach (var reconciliation in reconciliationByCurrency.Where(item => item.Difference != 0m))
            errors.Add(new PipelineError(
                "Validate",
                "ReconciliationMismatch",
                null,
                $"{reconciliation.Currency} source total {reconciliation.SourceTotal:0.00} does not reconcile to transformed total {reconciliation.TransformedTotal:0.00}. Difference: {reconciliation.Difference:0.00}."));

        var accountsMapped = transformedTransactions.Count;
        var validDates = transformedTransactions.Count;
        var isValid = errors.Count == 0
            && stagedTransactions.Count == transformedTransactions.Count
            && accountsMapped == stagedTransactions.Count
            && validDates == stagedTransactions.Count;

        return new ValidationResult(
            stagedTransactions.Count,
            accountsMapped,
            validDates,
            transformation.Errors.Count,
            duplicateIdCount,
            invalidAmounts,
            reconciliationByCurrency,
            reconciliationPassed,
            isValid,
            errors);
    }
}
