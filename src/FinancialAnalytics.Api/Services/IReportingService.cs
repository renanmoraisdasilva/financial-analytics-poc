using FinancialAnalytics.Api.Contracts.Reports;

namespace FinancialAnalytics.Api.Services;

public interface IReportingService
{
    Task<PipelineRun?> GetRunAsync(long pipelineRunId, CancellationToken cancellationToken = default);
    Task<FinancialReportResponse> GetFinancialReportAsync(DateOnly from, DateOnly to, string? entity, CancellationToken cancellationToken = default);
}
