using FinancialAnalytics.Api.Contracts.Pipeline;
using FinancialAnalytics.Api.Contracts.Pagination;
using FinancialAnalytics.Api.Contracts.Staging;
using FinancialAnalytics.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace FinancialAnalytics.Api.Controllers;

[ApiController]
[Route("api/pipeline")]
public sealed class PipelineController(
    PipelineService pipelineService,
    IReportingService reportingService,
    IAnalyticsReadService analyticsReadService,
    ILogger<PipelineController> logger) : ControllerBase
{
    [HttpPost("run")]
    [ProducesResponseType(typeof(PipelineRunResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(PipelineRunResponse), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public async Task<ActionResult<PipelineRunResponse>> Run(
        [FromQuery] string? scenario,
        CancellationToken cancellationToken)
    {
        if (!PipelineScenarios.TryNormalize(scenario, out var selectedScenario))
            return BadRequest("Unknown pipeline scenario.");

        try
        {
            var execution = await pipelineService.RunAsync(selectedScenario, cancellationToken);
            var response = ToResponse(execution.Run, execution.Validation, execution.Errors);
            return execution.Run.Status == "Completed"
                ? Ok(response)
                : StatusCode(GetFailureStatusCode(execution.Errors), response);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (DbException exception)
        {
            logger.LogError(exception, "Pipeline run failed because a required data source or database is unavailable.");
            return StatusCode(StatusCodes.Status503ServiceUnavailable);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Pipeline run failed unexpectedly.");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("reset")]
    [ProducesResponseType(typeof(PipelineResetResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<PipelineResetResponse>> Reset(CancellationToken cancellationToken)
    {
        return Ok(await pipelineService.ResetAsync(cancellationToken));
    }

    [HttpGet("runs/{pipelineRunId:long}")]
    [ProducesResponseType(typeof(PipelineRunResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PipelineRunResponse>> Details(long pipelineRunId, CancellationToken cancellationToken)
    {
        var run = await reportingService.GetRunAsync(pipelineRunId, cancellationToken);
        return run is null ? NotFound() : Ok(ToResponse(run, null, []));
    }

    [HttpGet("runs/{pipelineRunId:long}/staging")]
    [ProducesResponseType(typeof(PagedResponse<StagingTransactionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PagedResponse<StagingTransactionResponse>>> Staging(
        long pipelineRunId,
        [FromQuery] int page = Pagination.DefaultPage,
        [FromQuery] int pageSize = Pagination.DefaultPageSize,
        CancellationToken cancellationToken = default)
    {
        if (!Pagination.IsValid(page, pageSize))
            return BadRequest($"page must be at least 1 and pageSize must be between 1 and {Pagination.MaxPageSize}.");

        var records = await analyticsReadService.GetStagingTransactionsAsync(pipelineRunId, page, pageSize, cancellationToken);
        return records is null ? NotFound() : Ok(records);
    }

    [HttpGet("runs/{pipelineRunId:long}/transformations")]
    [ProducesResponseType(typeof(PagedResponse<PipelineTransformationResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PagedResponse<PipelineTransformationResponse>>> Transformations(
        long pipelineRunId,
        [FromQuery] int page = Pagination.DefaultPage,
        [FromQuery] int pageSize = Pagination.DefaultPageSize,
        CancellationToken cancellationToken = default)
    {
        if (!Pagination.IsValid(page, pageSize))
            return BadRequest($"page must be at least 1 and pageSize must be between 1 and {Pagination.MaxPageSize}.");

        var records = await analyticsReadService.GetTransformationsAsync(pipelineRunId, page, pageSize, cancellationToken);
        return records is null ? NotFound() : Ok(records);
    }

    [HttpGet("runs/{pipelineRunId:long}/validation")]
    [ProducesResponseType(typeof(PipelineValidationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PipelineValidationResponse>> Validation(long pipelineRunId, CancellationToken cancellationToken)
    {
        var result = await analyticsReadService.GetValidationAsync(pipelineRunId, cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    private static PipelineRunResponse ToResponse(
        PipelineRun run,
        ValidationResult? validation,
        IReadOnlyList<PipelineError> errors) => new(
        run.PipelineRunId, run.Status, run.StartedAt, run.CompletedAt,
        run.RecordsExtracted, run.RecordsTransformed, run.RecordsValidated,
        run.RecordsLoaded, run.RecordsInserted, run.RecordsAlreadyExisting, run.RecordsFailed,
        validation is null ? null : new PipelineValidationResponse(
            validation.RecordsReceived, validation.AccountsMapped, validation.ValidDates,
            validation.TransformationErrors,
            validation.Duplicates, validation.InvalidAmounts,
            validation.ReconciliationByCurrency
                .Select(item => new CurrencyReconciliationResponse(
                    item.Currency, item.SourceTotal, item.TransformedTotal, item.Difference))
                .ToList(),
            validation.ReconciliationPassed, validation.IsValid,
            validation.Errors),
        errors);

    private static int GetFailureStatusCode(IReadOnlyList<PipelineError> errors)
    {
        if (errors.Any(error => error.Code == "InfrastructureUnavailable"))
            return StatusCodes.Status503ServiceUnavailable;

        if (errors.Any(error => error.Code == "UnexpectedFailure"))
            return StatusCodes.Status500InternalServerError;

        return StatusCodes.Status422UnprocessableEntity;
    }
}
