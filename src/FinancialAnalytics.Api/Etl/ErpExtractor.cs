using FinancialAnalytics.Api.Contracts.Pagination;
using Microsoft.EntityFrameworkCore;

namespace FinancialAnalytics.Api;

public sealed class ErpExtractor(FakeErpDbContext db) : IErpExtractor
{
    public async Task<PagedResponse<ExtractedTransaction>> ExtractPageAsync(
        int page = Pagination.DefaultPage,
        int pageSize = Pagination.DefaultPageSize,
        CancellationToken cancellationToken = default)
    {
        var query = CreateTransactionQuery();
        var sourceCount = await query.CountAsync(cancellationToken);
        var skip = (page - 1) * pageSize;
        var transactions = await query
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResponse<ExtractedTransaction>(transactions, page, pageSize, sourceCount);
    }

    public async Task<IReadOnlyList<ExtractedTransaction>> ExtractAsync(
        string scenario = PipelineScenarios.Happy,
        CancellationToken cancellationToken = default)
    {
        var transactions = await CreateTransactionQuery()
            .ToListAsync(cancellationToken);

        if (scenario == PipelineScenarios.TransformFailure)
        {
            return transactions
                .Select(transaction => transaction.SourceTransactionId == "A005"
                    ? transaction with { TransactionDate = new DateOnly(2021, 1, 21) }
                    : transaction)
                .ToList();
        }

        return transactions;
    }

    private IQueryable<ExtractedTransaction> CreateTransactionQuery() => db.Transactions
        .AsNoTracking()
        .OrderBy(transaction => transaction.CreatedAt)
        .ThenBy(transaction => transaction.TransactionId)
        .Select(transaction => new ExtractedTransaction(
            transaction.TransactionId,
            transaction.TransactionDate,
            transaction.Account.AccountCode,
            transaction.Account.AccountName,
            transaction.Entity.EntityCode,
            transaction.Amount,
            transaction.CurrencyCode,
            transaction.Description));
}
