using FinancialAnalytics.Api.Contracts.AnalyticalRecords;
using FinancialAnalytics.Api.Contracts.Pagination;
using FinancialAnalytics.Api.Contracts.Pipeline;
using FinancialAnalytics.Api.Contracts.Source;
using FinancialAnalytics.Api.Contracts.Staging;

namespace FinancialAnalytics.Api.Services;

public interface IAnalyticsReadService
{
    Task<PagedResponse<SourceTransactionResponse>> GetSourceTransactionsAsync(
        int page = Pagination.DefaultPage,
        int pageSize = Pagination.DefaultPageSize,
        CancellationToken cancellationToken = default);
    Task<PagedResponse<StagingTransactionResponse>?> GetStagingTransactionsAsync(long pipelineRunId, int page = Pagination.DefaultPage, int pageSize = Pagination.DefaultPageSize, CancellationToken cancellationToken = default);
    Task<PagedResponse<PipelineTransformationResponse>?> GetTransformationsAsync(long pipelineRunId, int page = Pagination.DefaultPage, int pageSize = Pagination.DefaultPageSize, CancellationToken cancellationToken = default);
    Task<PipelineValidationResponse?> GetValidationAsync(long pipelineRunId, CancellationToken cancellationToken = default);
    Task<AnalyticalRecordsPageResponse> GetAnalyticalRecordsAsync(int page = Pagination.DefaultPage, int pageSize = Pagination.DefaultPageSize, CancellationToken cancellationToken = default);
}