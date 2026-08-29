using FinancialAnalytics.Api.Contracts.AnalyticalRecords;
using FinancialAnalytics.Api.Contracts.Pagination;
using FinancialAnalytics.Api.Contracts.Pipeline;
using FinancialAnalytics.Api.Contracts.Source;
using FinancialAnalytics.Api.Contracts.Staging;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FinancialAnalytics.Api.Services;

public sealed class AnalyticsReadService(
    FinancialAnalyticsDbContext db,
    IErpExtractor extractor,
    PipelineTransformationQuery transformationQuery) : IAnalyticsReadService
{
    public async Task<PagedResponse<SourceTransactionResponse>> GetSourceTransactionsAsync(
        int page = Pagination.DefaultPage,
        int pageSize = Pagination.DefaultPageSize,
        CancellationToken cancellationToken = default)
    {
        var transactions = await extractor.ExtractPageAsync(page, pageSize, cancellationToken);
        var records = transactions.Items.Select(x => new SourceTransactionResponse(
            x.SourceTransactionId, x.TransactionDate, x.SourceAccountCode, x.SourceAccountName,
            x.SourceEntityCode, x.Amount, x.CurrencyCode, x.Description)).ToList();
        return new PagedResponse<SourceTransactionResponse>(records, transactions.Page, transactions.PageSize, transactions.TotalCount);
    }

    public async Task<PagedResponse<StagingTransactionResponse>?> GetStagingTransactionsAsync(long pipelineRunId, int page = Pagination.DefaultPage, int pageSize = Pagination.DefaultPageSize, CancellationToken cancellationToken = default)
    {
        if (!await db.PipelineRuns.AsNoTracking().AnyAsync(x => x.PipelineRunId == pipelineRunId, cancellationToken))
            return null;

        var query = db.StgTransactions.AsNoTracking()
            .Where(x => x.PipelineRunId == pipelineRunId)
            .OrderBy(x => x.StgTransactionId)
            .Select(x => new StagingTransactionResponse(
                x.PipelineRunId, x.SourceTransactionId, x.TransactionDate, x.SourceAccountCode,
                x.SourceAccountName, x.SourceEntityCode, x.Amount, x.CurrencyCode, x.Description));
        return await ToPageAsync(query, page, pageSize, cancellationToken);
    }

    public async Task<PagedResponse<PipelineTransformationResponse>?> GetTransformationsAsync(long pipelineRunId, int page = Pagination.DefaultPage, int pageSize = Pagination.DefaultPageSize, CancellationToken cancellationToken = default)
    {
        if (!await db.PipelineRuns.AsNoTracking().AnyAsync(x => x.PipelineRunId == pipelineRunId, cancellationToken))
            return null;

        return await ToPageAsync(transformationQuery.Build(pipelineRunId), page, pageSize, cancellationToken);
    }

    public async Task<PipelineValidationResponse?> GetValidationAsync(long pipelineRunId, CancellationToken cancellationToken = default)
    {
        var validationJson = await db.PipelineRuns
            .AsNoTracking()
            .Where(x => x.PipelineRunId == pipelineRunId)
            .Select(x => x.ValidationResultJson)
            .SingleOrDefaultAsync(cancellationToken);
        if (validationJson is null)
            return null;

        var validation = JsonSerializer.Deserialize<ValidationResult>(validationJson)
            ?? throw new InvalidOperationException($"Pipeline run {pipelineRunId} has an invalid validation result.");
        return ToValidationResponse(validation);
    }

    public async Task<AnalyticalRecordsPageResponse> GetAnalyticalRecordsAsync(int page = Pagination.DefaultPage, int pageSize = Pagination.DefaultPageSize, CancellationToken cancellationToken = default)
    {
        var query = db.FactGl.AsNoTracking()
            .OrderBy(x => x.FactGLKey)
            .Select(x => new AnalyticalRecordResponse(
                x.SourceSystem, x.SourceTransactionId, x.Date.Date, x.Account.AccountCode,
                x.Account.AccountName, x.Account.AccountCategory, x.Entity.EntityCode,
                x.Currency.CurrencyCode, x.Amount));
        var pageResponse = await ToPageAsync(query, page, pageSize, cancellationToken);
        var summary = await db.FactGl
            .AsNoTracking()
            .GroupBy(_ => 1)
            .Select(group => new
            {
                AccountCount = group.Select(x => x.AccountKey).Distinct().Count(),
                EntityCount = group.Select(x => x.EntityKey).Distinct().Count(),
                DateCount = group.Select(x => x.DateKey).Distinct().Count(),
                CurrencyCount = group.Select(x => x.CurrencyKey).Distinct().Count()
            })
            .SingleOrDefaultAsync(cancellationToken);

        return new AnalyticalRecordsPageResponse(
            pageResponse.Items,
            pageResponse.Page,
            pageResponse.PageSize,
            pageResponse.TotalCount,
            summary?.AccountCount ?? 0,
            summary?.EntityCount ?? 0,
            summary?.DateCount ?? 0,
            summary?.CurrencyCount ?? 0);
    }

    private static async Task<PagedResponse<T>> ToPageAsync<T>(IQueryable<T> query, int page, int pageSize, CancellationToken cancellationToken)
    {
        var totalCount = await query.CountAsync(cancellationToken);
        var records = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        return new PagedResponse<T>(records, page, pageSize, totalCount);
    }

    private static PipelineValidationResponse ToValidationResponse(ValidationResult validation) => new(
        validation.RecordsReceived, validation.AccountsMapped, validation.ValidDates,
        validation.TransformationErrors,
        validation.Duplicates, validation.InvalidAmounts,
        validation.ReconciliationByCurrency
            .Select(item => new CurrencyReconciliationResponse(
                item.Currency, item.SourceTotal, item.TransformedTotal, item.Difference))
            .ToList(),
        validation.ReconciliationPassed, validation.IsValid, validation.Errors);
}