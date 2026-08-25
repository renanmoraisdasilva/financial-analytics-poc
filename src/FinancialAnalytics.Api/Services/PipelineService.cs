using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Text.Json;

namespace FinancialAnalytics.Api;

public sealed class PipelineService(
    FinancialAnalyticsDbContext analyticsDb,
    IErpExtractor extractor,
    IDataTransformer transformer,
    IDataValidator validator,
    IDataLoader loader,
    ILogger<PipelineService> logger)
{
    public async Task<PipelineExecutionResult> RunAsync(
        string scenario = PipelineScenarios.Happy,
        CancellationToken cancellationToken = default)
    {
        var run = await StartRunAsync(scenario, cancellationToken);

        try
        {
            var extracted = await ExtractAsync(run, scenario, cancellationToken);
            var staged = await StageAsync(run, extracted, cancellationToken);
            var transformation = await TransformAsync(run, staged, cancellationToken);

            transformation = PipelineScenarios.ApplyValidationFailure(transformation, scenario);

            if (transformation.Errors.Count > 0)
                return await FailTransformationAsync(run, transformation, cancellationToken);

            var validation = Validate(run, staged, transformation);
            run.ValidationResultJson = JsonSerializer.Serialize(validation);

            if (validation.IsValid is false)
                return await FailValidationAsync(run, validation, cancellationToken);

            await LoadAsync(run, transformation.Transactions, cancellationToken);
            return await CompleteAsync(run, validation, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (DbException exception)
        {
            logger.LogError(exception, "Pipeline {PipelineRunId} could not reach a required data source or database.", run.PipelineRunId);
            return await FailAsync(run, [new PipelineError(
                "Pipeline",
                "InfrastructureUnavailable",
                null,
                "A required data source or database is unavailable.")], cancellationToken);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Pipeline {PipelineRunId} failed unexpectedly.", run.PipelineRunId);
            return await FailAsync(run, [new PipelineError(
                "Pipeline",
                "UnexpectedFailure",
                null,
                "The pipeline failed unexpectedly. See server logs for details.")], cancellationToken);
        }
    }

    public async Task<PipelineResetResponse> ResetAsync(CancellationToken cancellationToken = default)
    {
        await using var transaction = await analyticsDb.Database.BeginTransactionAsync(cancellationToken);
        var facts = await analyticsDb.FactGl.ExecuteDeleteAsync(cancellationToken);
        var staging = await analyticsDb.StgTransactions.ExecuteDeleteAsync(cancellationToken);
        var pipelineRuns = await analyticsDb.PipelineRuns.ExecuteDeleteAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        logger.LogInformation(
            "Pipeline reset deleted {FactCount} facts, {StagingCount} staging records, and {PipelineRunCount} pipeline runs.",
            facts,
            staging,
            pipelineRuns);
        return new PipelineResetResponse(new PipelineResetCounts(facts, staging, pipelineRuns));
    }

    private async Task<PipelineRun> StartRunAsync(string scenario, CancellationToken cancellationToken)
    {
        var run = new PipelineRun
        {
            StartedAt = DateTime.UtcNow,
            Status = "Running",
            Scenario = scenario
        };
        analyticsDb.PipelineRuns.Add(run);
        await analyticsDb.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Pipeline {PipelineRunId} started.", run.PipelineRunId);
        return run;
    }

    private async Task<IReadOnlyList<ExtractedTransaction>> ExtractAsync(
        PipelineRun run,
        string scenario,
        CancellationToken cancellationToken)
    {
        var extracted = await extractor.ExtractAsync(scenario, cancellationToken);
        run.RecordsExtracted = extracted.Count;
        logger.LogInformation("Pipeline {PipelineRunId} extracted {RecordCount} records.", run.PipelineRunId, extracted.Count);
        return extracted;
    }

    private async Task<IReadOnlyList<StgTransaction>> StageAsync(
        PipelineRun run,
        IReadOnlyList<ExtractedTransaction> extracted,
        CancellationToken cancellationToken)
    {
        var staged = extracted.Select(item => new StgTransaction
        {
            PipelineRunId = run.PipelineRunId,
            SourceTransactionId = item.SourceTransactionId,
            TransactionDate = item.TransactionDate,
            SourceAccountCode = item.SourceAccountCode,
            SourceAccountName = item.SourceAccountName,
            SourceEntityCode = item.SourceEntityCode,
            Amount = item.Amount,
            CurrencyCode = item.CurrencyCode,
            Description = item.Description
        }).ToList();
        await analyticsDb.StgTransactions.AddRangeAsync(staged, cancellationToken);
        await analyticsDb.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Pipeline {PipelineRunId} staged {RecordCount} records.", run.PipelineRunId, staged.Count);
        return staged;
    }

    private async Task<TransformationResult> TransformAsync(
        PipelineRun run,
        IReadOnlyList<StgTransaction> staged,
        CancellationToken cancellationToken)
    {
        var transformation = await transformer.TransformAsync(staged, cancellationToken);
        run.RecordsTransformed = transformation.Transactions.Count;
        logger.LogInformation(
            "Pipeline {PipelineRunId} transformed {RecordCount} records with {ErrorCount} errors.",
            run.PipelineRunId,
            transformation.Transactions.Count,
            transformation.Errors.Count);
        return transformation;
    }

    private ValidationResult Validate(
        PipelineRun run,
        IReadOnlyList<StgTransaction> staged,
        TransformationResult transformation)
    {
        var validation = validator.Validate(staged, transformation);
        var validationFailures = GetValidationFailureCount(validation);
        run.RecordsValidated = validation.RecordsReceived - validationFailures;
        logger.LogInformation(
            "Pipeline {PipelineRunId} validation passed: {IsValid}. Errors: {Errors}",
            run.PipelineRunId,
            validation.IsValid,
            string.Join("; ", validation.Errors.Select(error => error.Message)));
        return validation;
    }


    private async Task LoadAsync(
        PipelineRun run,
        IReadOnlyList<TransformedTransaction> transformed,
        CancellationToken cancellationToken)
    {
        var loadResult = await loader.LoadAsync(transformed, cancellationToken);
        run.RecordsLoaded = loadResult.RecordsProcessed;
        run.RecordsInserted = loadResult.RecordsInserted;
        run.RecordsAlreadyExisting = loadResult.RecordsAlreadyExisting;
        logger.LogInformation(
            "Pipeline {PipelineRunId} processed {ProcessedCount} records: {InsertedCount} inserted, {ExistingCount} already existing.",
            run.PipelineRunId,
            loadResult.RecordsProcessed,
            loadResult.RecordsInserted,
            loadResult.RecordsAlreadyExisting);
    }

    private async Task<PipelineExecutionResult> CompleteAsync(
        PipelineRun run,
        ValidationResult validation,
        CancellationToken cancellationToken)
    {
        run.Status = "Completed";
        run.CompletedAt = DateTime.UtcNow;
        await analyticsDb.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Pipeline {PipelineRunId} completed.", run.PipelineRunId);
        return new PipelineExecutionResult(run, validation, []);
    }

    private async Task<PipelineExecutionResult> FailTransformationAsync(
        PipelineRun run,
        TransformationResult transformation,
        CancellationToken cancellationToken)
    {
        logger.LogWarning(
            "Pipeline {PipelineRunId} skipped validation and load because transformation returned {ErrorCount} errors.",
            run.PipelineRunId,
            transformation.Errors.Count);
        return await FailAsync(run, transformation.Errors, cancellationToken, recordsFailed: transformation.Errors.Count);
    }

    private Task<PipelineExecutionResult> FailValidationAsync(
        PipelineRun run,
        ValidationResult validation,
        CancellationToken cancellationToken) =>
        FailAsync(run, validation.Errors, cancellationToken, validation, GetValidationFailureCount(validation));

    private async Task<PipelineExecutionResult> FailAsync(
        PipelineRun run,
        IReadOnlyList<PipelineError> errors,
        CancellationToken cancellationToken,
        ValidationResult? validation = null,
        int recordsFailed = 0)
    {
        run.Status = "Failed";
        run.CompletedAt = DateTime.UtcNow;
        run.RecordsFailed = recordsFailed;
        await analyticsDb.SaveChangesAsync(cancellationToken);
        logger.LogError("Pipeline {PipelineRunId} failed: {Errors}", run.PipelineRunId, errors);
        return new PipelineExecutionResult(run, validation, errors);
    }

    private static int GetValidationFailureCount(ValidationResult validation)
    {
        var recordFailures = Math.Max(
            validation.InvalidAmounts,
            Math.Max(
                validation.Duplicates,
                Math.Max(
                    validation.RecordsReceived - validation.AccountsMapped,
                    validation.RecordsReceived - validation.ValidDates)));

        return Math.Min(validation.RecordsReceived, recordFailures);
    }
}

public sealed record PipelineExecutionResult(
    PipelineRun Run,
    ValidationResult? Validation,
    IReadOnlyList<PipelineError> Errors);

public sealed record PipelineResetResponse(PipelineResetCounts RecordsDeleted);

public sealed record PipelineResetCounts(int Facts, int Staging, int PipelineRuns);
