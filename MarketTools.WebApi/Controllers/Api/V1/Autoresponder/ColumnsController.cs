using MarketTools.Application.Cases.Autoresponder.Columns.Models;
using MarketTools.Application.Cases.Autoresponder.Columns.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder
{
    [Route("api/v1/autoresponder/[controller]")]
    [ApiController]
    [Authorize]
    public class ColumnsController
        (IMediator _mediator)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRangeAsync()
        {
            GetListColumnsQuery query = new GetListColumnsQuery();
            IEnumerable<ColumnVm> result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
