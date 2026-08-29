using FinancialAnalytics.Api.Contracts.Pagination;

namespace FinancialAnalytics.Api;

public interface IErpExtractor
{
    Task<PagedResponse<ExtractedTransaction>> ExtractPageAsync(
        int page = Pagination.DefaultPage,
        int pageSize = Pagination.DefaultPageSize,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ExtractedTransaction>> ExtractAsync(
        string scenario = PipelineScenarios.Happy,
        CancellationToken cancellationToken = default);
}

public static class PipelineScenarios
{
    public const string Happy = "happy";
    public const string TransformFailure = "transform-failure";
    public const string ValidationFailure = "validation-failure";

    public static bool TryNormalize(string? value, out string scenario)
    {
        scenario = string.IsNullOrWhiteSpace(value) ? Happy : value.Trim().ToLowerInvariant();
        return scenario is Happy or TransformFailure or ValidationFailure;
    }

    public static TransformationResult ApplyValidationFailure(TransformationResult transformation, string scenario) =>
        scenario == ValidationFailure
            ? transformation with
            {
                Transactions = transformation.Transactions
                    .Select(transaction => transaction.SourceTransactionId == "A005"
                        ? transaction with { Amount = transaction.Amount + 10000m }
                        : transaction)
                    .ToList()
            }
            : transformation;
}

public sealed record ExtractedTransaction(
    string SourceTransactionId,
    DateOnly TransactionDate,
    string SourceAccountCode,
    string SourceAccountName,
    string SourceEntityCode,
    decimal Amount,
    string CurrencyCode,
    string? Description);
