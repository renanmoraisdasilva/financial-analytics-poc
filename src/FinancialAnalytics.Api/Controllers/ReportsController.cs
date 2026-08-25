using System.Globalization;
using FinancialAnalytics.Api.Contracts.Reports;
using FinancialAnalytics.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancialAnalytics.Api.Controllers;

[ApiController]
[Route("api/reports")]
public sealed class ReportsController(IReportingService reportingService) : ControllerBase
{
    [HttpGet("financial")]
    [ProducesResponseType(typeof(FinancialReportResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FinancialReportResponse>> Financial(
        [FromQuery(Name = "from")] string? from,
        [FromQuery(Name = "to")] string? to,
        [FromQuery] string? entity,
        CancellationToken cancellationToken)
    {
        if (!TryParseDate(from, out var fromDate) ||
            !TryParseDate(to, out var toDate))
        {
            return BadRequest("from and to must be valid dates in yyyy-MM-dd format.");
        }

        if (fromDate > toDate)
        {
            return BadRequest("from must be earlier than or equal to to.");
        }

        var report = await reportingService.GetFinancialReportAsync(
            fromDate,
            toDate,
            string.IsNullOrWhiteSpace(entity) ? null : entity,
            cancellationToken);

        return Ok(report);
    }

    private static bool TryParseDate(string? value, out DateOnly date)
    {
        return DateOnly.TryParseExact(
            value,
            "yyyy-MM-dd",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out date);
    }
}
