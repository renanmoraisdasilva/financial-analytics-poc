using FinancialAnalytics.Api.Contracts.Pipeline;
using Microsoft.EntityFrameworkCore;

namespace FinancialAnalytics.Api.Services;

public sealed class PipelineTransformationQuery(FinancialAnalyticsDbContext db)
{
    public IQueryable<PipelineTransformationResponse> Build(long pipelineRunId) =>
        from staging in db.StgTransactions.AsNoTracking()
        where staging.PipelineRunId == pipelineRunId
        join mapping in db.AccountMappings.AsNoTracking().Where(x => x.SourceSystem == PipelineSourceSystems.FakeErp)
            on staging.SourceAccountCode equals mapping.SourceAccountCode into mappingMatches
        from mapping in mappingMatches.DefaultIfEmpty()
        join account in db.DimAccounts.AsNoTracking()
            on mapping.AccountKey equals account.AccountKey into accountMatches
        from account in accountMatches.DefaultIfEmpty()
        join entity in db.DimEntities.AsNoTracking()
            on staging.SourceEntityCode equals entity.EntityCode into entityMatches
        from entity in entityMatches.DefaultIfEmpty()
        join date in db.DimDates.AsNoTracking()
            on staging.TransactionDate equals date.Date into dateMatches
        from date in dateMatches.DefaultIfEmpty()
        join currency in db.DimCurrencies.AsNoTracking()
            on staging.CurrencyCode equals currency.CurrencyCode into currencyMatches
        from currency in currencyMatches.DefaultIfEmpty()
        orderby staging.StgTransactionId
        select new PipelineTransformationResponse(
            staging.SourceTransactionId,
            staging.TransactionDate,
            staging.SourceAccountCode,
            staging.SourceAccountName,
            staging.SourceEntityCode,
            staging.Amount,
            staging.CurrencyCode,
            staging.Description,
            account == null ? null : account.AccountCode,
            account == null ? null : account.AccountName,
            account == null ? null : account.AccountCategory,
            account == null ? null : (int?)account.AccountKey,
            entity == null ? null : entity.EntityName,
            entity == null ? null : (int?)entity.EntityKey,
            date == null ? null : (int?)date.DateKey,
            currency == null ? null : currency.CurrencyName,
            currency == null ? null : (int?)currency.CurrencyKey,
            db.PipelineErrors
                .Where(error => error.PipelineRunId == staging.PipelineRunId
                    && error.SourceTransactionId == staging.SourceTransactionId
                    && error.Stage == PipelineStages.Transform)
                .OrderBy(error => error.PipelineErrorId)
                .Select(error => error.ErrorCode)
                .FirstOrDefault(),
            db.PipelineErrors
                .Where(error => error.PipelineRunId == staging.PipelineRunId
                    && error.SourceTransactionId == staging.SourceTransactionId
                    && error.Stage == PipelineStages.Transform)
                .OrderBy(error => error.PipelineErrorId)
                .Select(error => error.Message)
                .FirstOrDefault());
}