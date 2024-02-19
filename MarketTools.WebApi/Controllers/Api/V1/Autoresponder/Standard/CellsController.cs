using AutoMapper;
using MarketTools.Application.Requests.Autoresponder.Standard.Cells.Queries;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.Autoreponder.Standard;
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
            CellGetRangeQuery query = new CellGetRangeQuery { CollumnId = columnId };
            IEnumerable<StandardAutoresponderCellEntity> entites = await _mediator.Send(query, cancellationToken);

            IEnumerable<CellVm> result = _mapper.Map<IEnumerable<CellVm>>(entites);

            return Ok(result);
        }
    }
}
