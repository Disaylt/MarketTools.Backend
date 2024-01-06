using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Columns.Queries.GetRange;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
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
    public class ColumnsController
        (IMediator _mediator, IMapper _mapper)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRangeAsync(AutoresponderColumnType type, CancellationToken cancellationToken)
        {
            GetRangeQuery query = new GetRangeQuery { Type = type };
            IEnumerable<StandardAutoresponderColumnEntity> entities = await _mediator.Send(query, cancellationToken);

            IEnumerable<ColumnVm> viewClumns = _mapper.Map<IEnumerable<ColumnVm>>(entities);

            return Ok(viewClumns);
        }
    }
}
