using AutoMapper;
using MarketTools.Application.Interfaces.Requests;
using MarketTools.Application.Requests.MarketplaceConnections.Queries.GetRangePagination;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.WebApi.Models.Api.MarketplaceConnections;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.MarketplaceConnections
{
    [Route("api/v1/marketplace-connections")]
    [ApiController]
    [Authorize]
    public class MarketplaceConnectionsController(IMediator _mediator, IMapper _mapper)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRangeAsync([FromQuery] GetRangePaginationMarketplaceConnectionsQuery query)
        {
            IEnumerable<MarketplaceConnectionEntity> entities = await _mediator.Send(query);

            IEnumerable<MarketplaceConnectionVm> viewEntities = _mapper.Map<IEnumerable<MarketplaceConnectionVm>>(entities);

            return Ok(viewEntities);
        }
    }
}
