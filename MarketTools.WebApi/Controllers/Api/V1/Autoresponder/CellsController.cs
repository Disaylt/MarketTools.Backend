using MarketTools.Application.Cases.Autoresponder.Cells.Models;
using MarketTools.Application.Cases.Autoresponder.Cells.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder
{
    [Route("api/v1/autoresponder/[controller]")]
    [ApiController]
    [Authorize]
    public class CellsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(int columnId)
        {
            GetListCellsQuery query = new GetListCellsQuery { CollumnId = columnId };
            IEnumerable<CellVm> cells = await _mediator.Send(query);

            return Ok(cells);
        }
    }
}
