using AutoMapper;
using MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Queries.GetRange;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.Autoreponder.Standard;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard.Connection
{
    [Route("api/v1/autoresponder/standard/connection/[controller]")]
    [ApiController]
    [Authorize]
    public class RatingsController(IMediator _mediator, IMapper _mapper)
        : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetRangeAsync(int connectionId)
        {
            GetRangeRatingsQuery query = new GetRangeRatingsQuery
            {
                ConnectionId = connectionId
            };
            IEnumerable<StandardAutoresponderConnectionRatingEntity> ratings = await _mediator.Send(query);
            IEnumerable<RatingVm> viewRatings = _mapper.Map<IEnumerable<RatingVm>>(ratings);

            return Ok(viewRatings);
        }
    }
}
