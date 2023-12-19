using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Commands.Create;
using MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Commands.Update;
using MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Models;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.Autoreponder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard
{
    [Route("api/v1/autoresponder/standard/recommendation-product")]
    [ApiController]
    [Authorize]
    public class RecommendationProductController
        (IMediator _mediator,
        IMapper _mapper)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RecommendationProductCreateDto body, CancellationToken cancellationToken)
        {
            CreateCommand command = _mapper.Map<CreateCommand>(body);
            RecommendationProductVm result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            DefaultDeleteCommand<StandardAutoresponderRecommendationProduct> command = new DefaultDeleteCommand<StandardAutoresponderRecommendationProduct> { Id = id };
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RecommendationProductUpdateDto body, CancellationToken cancellationToken)
        {
            UpdateCommand command = _mapper.Map<UpdateCommand>(body);
            await _mediator.Send(command);

            return Ok();
        }
    }
}
