using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Queries.GetRange;
using MarketTools.Application.Interfaces.Excel;
using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Queries.Count;
using MarketTools.Domain.Common;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.WebApi.Models.Api.Autoreponder;
using MarketTools.WebApi.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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
            IEnumerable<RecommendationProductVm> products = await GetProductsAsync(webQuery, cancellationToken);
            int totalProducts = await CountProductsAsync(webQuery, cancellationToken);

            PageResult<RecommendationProductVm> pageResult = new PageResult<RecommendationProductVm>(totalProducts, products);

            return Ok(pageResult);
        }

        private async Task<int> CountProductsAsync(RecommendationProductGetRangeDto webQuery, CancellationToken cancellationToken)
        {
            CountQuery query = new CountQuery
            {
                Article = webQuery.Article,
                MarketplaceName = webQuery.MarketplaceName
            };

            return await _mediator.Send(query);
        }

        private async Task<IEnumerable<RecommendationProductVm>> GetProductsAsync(RecommendationProductGetRangeDto webQuery, CancellationToken cancellationToken)
        {
            GetRangeQuery query = _mapper.Map<GetRangeQuery>(webQuery);

            IEnumerable<StandardAutoresponderRecommendationProductEntity> entites = await _mediator.Send(query, cancellationToken);

            return _mapper.Map<IEnumerable<RecommendationProductVm>>(entites);
        }
    }
}
