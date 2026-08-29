using FinancialAnalytics.Api.Contracts.Reports;
using Microsoft.EntityFrameworkCore;

namespace FinancialAnalytics.Api.Services;

public sealed class ReportingService(FinancialAnalyticsDbContext db) : IReportingService
{
    public Task<PipelineRun?> GetRunAsync(long pipelineRunId, CancellationToken cancellationToken = default) =>
        db.PipelineRuns
            .AsNoTracking()
            .Include(x => x.Errors)
            .SingleOrDefaultAsync(x => x.PipelineRunId == pipelineRunId, cancellationToken);

    public async Task<FinancialReportResponse> GetFinancialReportAsync(
        DateOnly from,
        DateOnly to,
        string? entity,
        CancellationToken cancellationToken = default)
    {
        var query = db.FactGl.AsNoTracking()
            .Where(x => x.Date.Date >= from && x.Date.Date <= to && (entity == null || x.Entity.EntityCode == entity));

        var lines = await query
            .GroupBy(x => new
            {
                x.Account.AccountCode,
                x.Account.AccountName,
                x.Account.AccountCategory
            })
            .Select(x => new
            {
                x.Key.AccountCode,
                x.Key.AccountName,
                x.Key.AccountCategory,
                Amount = x.Sum(y => y.Amount)
            })
            .OrderBy(x => x.AccountCode)
            .ToListAsync(cancellationToken);

        var currencyCodes = await query
            .Select(x => x.Currency.CurrencyCode)
            .Distinct()
            .ToListAsync(cancellationToken);
        var reportingCurrency = entity is null || currencyCodes.Count != 1 ? null : currencyCodes[0];

        var revenueLines = lines.Where(x => x.AccountCategory == "Revenue")
            .Select(x => new FinancialReportLineResponse(x.AccountCode, x.AccountName, x.Amount))
            .ToList();
        var cogsLines = lines.Where(x => x.AccountCategory == "COGS")
            .Select(x => new FinancialReportLineResponse(x.AccountCode, x.AccountName, -x.Amount))
            .ToList();
        var operatingExpenseLines = lines.Where(x => x.AccountCategory == "Operating Expense")
            .Select(x => new FinancialReportLineResponse(x.AccountCode, x.AccountName, -x.Amount))
            .ToList();
        var revenue = revenueLines.Sum(x => x.Amount);
        var cogs = cogsLines.Sum(x => x.Amount);
        var operatingExpenses = operatingExpenseLines.Sum(x => x.Amount);
        var grossProfit = revenue - cogs;

        return new FinancialReportResponse(
            new FinancialReportPeriodResponse(from, to),
            entity,
            reportingCurrency,
            new FinancialReportSectionResponse(revenue, revenueLines),
            new FinancialReportSectionResponse(cogs, cogsLines),
            grossProfit,
            revenue == 0m ? 0m : grossProfit / revenue,
            new FinancialReportSectionResponse(operatingExpenses, operatingExpenseLines),
            grossProfit - operatingExpenses);
    }
}
