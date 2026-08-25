using FinancialAnalytics.Api.Contracts.AnalyticalRecords;
using FinancialAnalytics.Api.Contracts.Pagination;
using FinancialAnalytics.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancialAnalytics.Api.Controllers;

[ApiController]
[Route("api/analytical-records")]
public sealed class AnalyticalRecordsController(IAnalyticsReadService analyticsReadService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(AnalyticalRecordsPageResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<AnalyticalRecordsPageResponse>> Get(
        [FromQuery] int page = Pagination.DefaultPage,
        [FromQuery] int pageSize = Pagination.DefaultPageSize,
        CancellationToken cancellationToken = default)
    {
        if (!Pagination.IsValid(page, pageSize))
            return BadRequest($"page must be at least 1 and pageSize must be between 1 and {Pagination.MaxPageSize}.");

        return Ok(await analyticsReadService.GetAnalyticalRecordsAsync(page, pageSize, cancellationToken));
    }
}