using MarketTools.Application.Cases.Autoresponder.Standard.Columns.Models;
using MarketTools.Application.Cases.Autoresponder.Standard.Columns.Queries.GetRange;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard
{
    [Route("api/v1/autoresponder/standard/[controller]")]
    [ApiController]
    [Authorize]
    public class ColumnsController
        (IMediator _mediator)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRangeAsync(CancellationToken cancellationToken)
        {
            GetRangeQuery query = new GetRangeQuery();
            IEnumerable<ColumnVm> result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}
