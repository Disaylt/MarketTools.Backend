using AutoMapper;
using MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.Autoreponder.Standard;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard.Connection
{
    [Route("api/v1/autoresponder/standard/connection/[controller]")]
    [ApiController]
    [Authorize]
    public class RatingController(IMediator _mediator, IMapper _mapper)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromQuery] AddRatingQuery httpQuery)
        {
            AddRatingCommand command = new AddRatingCommand
            {
                ConnectionId = httpQuery.ConnectionId,
                Rating = httpQuery.Rating
            };

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("template")]
        public async Task<IActionResult> AddTemplateAsync([FromQuery] AddTemplateToRatingCommand httpQuery)
        {
            StandardAutoresponderTemplateEntity template = await _mediator.Send(httpQuery);
            TemplateVm viewTemplate = _mapper.Map<TemplateVm>(template);

            return Ok(viewTemplate);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] RatingDeleteCommand httpQuery)
        {
            await _mediator.Send(httpQuery);

            return Ok();
        }

        [HttpDelete]
        [Route("template")]
        public async Task<IActionResult> DeleteTemplateAsync([FromQuery] DeleteTemplateCommand httpQuery)
        {
            await _mediator.Send(httpQuery);

            return Ok();
        }
    }
}
