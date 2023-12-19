using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Models;
using MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Queries.GetRange;
using MarketTools.Domain.Common;
using MarketTools.WebApi.Models.Api.Autoreponder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard
{
    [Route("api/v1/autoresponder/standard/recommendation-products")]
    [ApiController]
    [Authorize]
    public class RecommendationProductsController
        (IMediator _mediator,
        IMapper _mapper)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] RecommendationProductGetRangeDto webQuery, CancellationToken cancellationToken)
        {
            GetRangeQuery query = _mapper.Map<GetRangeQuery>(webQuery);
            PageResult<RecommendationProductVm> result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
