using Microsoft.EntityFrameworkCore;

namespace FinancialAnalytics.Api;

public sealed class DataTransformer(
    FinancialAnalyticsDbContext db) : IDataTransformer
{
    private const string SourceSystem = "FakeERP";
    private static readonly IReadOnlyDictionary<string, string> SourceToCanonicalAccountCodes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        ["4000"] = "REV-PROD",
        ["4010"] = "REV-SERV",
        ["5000"] = "COGS-MAT",
        ["6000"] = "OPEX-SAL"
    };
    public async Task<TransformationResult> TransformAsync(
        IEnumerable<StgTransaction> stagedTransactions,
        CancellationToken cancellationToken = default)
    {
        var accounts = await db.DimAccounts
            .AsNoTracking()
            .ToDictionaryAsync(x => x.AccountCode, StringComparer.OrdinalIgnoreCase, cancellationToken);
        var entities = await db.DimEntities
            .AsNoTracking()
            .ToDictionaryAsync(x => x.EntityCode, StringComparer.OrdinalIgnoreCase, cancellationToken);
        var dates = await db.DimDates
            .AsNoTracking()
            .ToDictionaryAsync(x => x.Date);
        var currencies = await db.DimCurrencies
            .AsNoTracking()
            .ToDictionaryAsync(x => x.CurrencyCode, StringComparer.OrdinalIgnoreCase, cancellationToken);

        var transformed = new List<TransformedTransaction>();
        var errors = new List<PipelineError>();
        foreach (var staged in stagedTransactions)
        {
            var result = Transform(staged, accounts, entities, dates, currencies);
            if (result.Error is null)
                transformed.Add(result.Transaction!);
            else
                errors.Add(result.Error);
        }

        return new TransformationResult(transformed, errors);
    }

    private static (TransformedTransaction? Transaction, PipelineError? Error) Transform(
        StgTransaction staged,
        IReadOnlyDictionary<string, DimAccount> accounts,
        IReadOnlyDictionary<string, DimEntity> entities,
        IReadOnlyDictionary<DateOnly, DimDate> dates,
        IReadOnlyDictionary<string, DimCurrency> currencies)
    {
        if (!SourceToCanonicalAccountCodes.TryGetValue(staged.SourceAccountCode, out var canonicalAccountCode)
            || !accounts.TryGetValue(canonicalAccountCode, out var account))
            return Error(staged, "UnknownAccount", $"Source account '{staged.SourceAccountCode}' has no canonical mapping.");

        if (!entities.TryGetValue(staged.SourceEntityCode, out var entity))
            return Error(staged, "UnknownEntity", $"Source entity '{staged.SourceEntityCode}' has no analytical mapping.");

        if (!dates.TryGetValue(staged.TransactionDate, out var date))
            return Error(staged, "MissingDateDimension", $"No analytical date exists for '{staged.TransactionDate:yyyy-MM-dd}'.");

        if (!currencies.TryGetValue(staged.CurrencyCode, out var currency))
            return Error(staged, "UnknownCurrency", $"Source currency '{staged.CurrencyCode}' has no analytical mapping.");

        return (new TransformedTransaction(
                SourceSystem,
                staged.SourceTransactionId,
                staged.TransactionDate,
                account.AccountKey,
                account.AccountCode,
                account.AccountName,
                account.AccountCategory,
                entity.EntityKey,
                date.DateKey,
                currency.CurrencyKey,
                staged.Amount), null);
    }

    private static (TransformedTransaction? Transaction, PipelineError? Error) Error(
        StgTransaction staged,
        string code,
        string message) =>
        (null, new PipelineError("Transform", code, staged.SourceTransactionId, message));
}
