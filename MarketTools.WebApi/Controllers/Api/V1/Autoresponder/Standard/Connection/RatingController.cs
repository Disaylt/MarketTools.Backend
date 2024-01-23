using AutoMapper;
using MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands.Add;
using MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands.AddTemplate;
using MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands.DeleteScore;
using MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands.DeleteTemplate;
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
        public async Task<IActionResult> AddAsync(int rating, int connectionId)
        {
            AddRatingCommand command = new AddRatingCommand
            {
                ConnectionId = connectionId,
                Rating = rating
            };

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("template")]
        public async Task<IActionResult> AddTemplateAsync(int rating, int connectionId, int templateId)
        {
            AddTemplateToRatingCommand command = new AddTemplateToRatingCommand
            {
                ConnectionId = connectionId,
                Rating = rating,
                TemplateId = templateId
            };

            StandardAutoresponderTemplateEntity template = await _mediator.Send(command);
            TemplateVm viewTemplate = _mapper.Map<TemplateVm>(template);

            return Ok(viewTemplate);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int rating, int connectionId)
        {
            RatingDeleteScoreCommand command = new RatingDeleteScoreCommand
            {
                ConnectionId = connectionId,
                Rating = rating
            };

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        [Route("template")]
        public async Task<IActionResult> DeleteTemplateAsync(int rating, int connectionId, int templateId)
        {
            RatingDeleteTemplateCommand command = new RatingDeleteTemplateCommand
            {
                ConnectionId = connectionId,
                Rating = rating,
                TemplateId = templateId
            };

            await _mediator.Send(command);

            return Ok();
        }
    }
}
