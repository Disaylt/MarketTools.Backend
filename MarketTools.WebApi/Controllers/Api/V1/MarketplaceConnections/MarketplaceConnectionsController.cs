using AutoMapper;
using MarketTools.Application.Models.Queries;
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
        public async Task<IActionResult> GetRangeAsync([FromQuery] GetRangeEndpointQuery query)
        {
            GetRangeQuery<MarketplaceConnectionEntity> mediatorQuery = CreateMediatorQuery(query);

            IEnumerable<MarketplaceConnectionEntity> entities = await _mediator.Send(mediatorQuery);

            IEnumerable<MarketplaceConnectionVm> viewEntities = _mapper.Map<IEnumerable<MarketplaceConnectionVm>>(entities);

            return Ok(viewEntities);
        }

        private GetRangeQuery<MarketplaceConnectionEntity> CreateMediatorQuery(GetRangeEndpointQuery query)
        {
            GetRangeQuery<MarketplaceConnectionEntity> mediatorQuery = new MarketplaceConnectionsQueryFactory()
                .CreateGetRangeQuery(query.ConnectionType);
            mediatorQuery.Skip = query.Skip;
            mediatorQuery.Take = query.Take;

            return mediatorQuery;
        }
    }
}
