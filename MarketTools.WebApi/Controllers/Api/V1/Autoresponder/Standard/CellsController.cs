using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Cells.Queries.GetRange;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.Autoreponder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard
{
    [Route("api/v1/autoresponder/standard/[controller]")]
    [ApiController]
    [Authorize]
    public class CellsController(IMediator _mediator, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(int columnId, CancellationToken cancellationToken)
        {
            GetRangeQuery query = new GetRangeQuery { CollumnId = columnId };
            IEnumerable<StandardAutoresponderCell> entites = await _mediator.Send(query, cancellationToken);

            IEnumerable<CellVm> result = _mapper.Map<IEnumerable<CellVm>>(entites);

            return Ok(result);
        }
    }
}
