using FinancialAnalytics.Api.Contracts.Source;
using FinancialAnalytics.Api.Contracts.Pagination;
using FinancialAnalytics.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancialAnalytics.Api.Controllers;

[ApiController]
[Route("api/source")]
public sealed class SourceController(IAnalyticsReadService analyticsReadService) : ControllerBase
{
    [HttpGet("transactions")]
    [ProducesResponseType(typeof(PagedResponse<SourceTransactionResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<SourceTransactionResponse>>> Transactions(
        [FromQuery] int page = Pagination.DefaultPage,
        [FromQuery] int pageSize = Pagination.DefaultPageSize,
        CancellationToken cancellationToken = default)
    {
        if (!Pagination.IsValid(page, pageSize))
            return BadRequest($"page must be at least 1 and pageSize must be between 1 and {Pagination.MaxPageSize}.");

        return Ok(await analyticsReadService.GetSourceTransactionsAsync(page, pageSize, cancellationToken));
    }
}