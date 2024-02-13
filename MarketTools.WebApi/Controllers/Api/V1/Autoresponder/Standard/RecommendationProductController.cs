using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Commands.Create;
using MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Commands.Update;
using MarketTools.Application.Models.Requests;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.Autoreponder.Standard;
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
            RecommendationProductCreateCommand command = _mapper.Map<RecommendationProductCreateCommand>(body);
            StandardAutoresponderRecommendationProductEntity entiry = await _mediator.Send(command);

            RecommendationProductVm result = _mapper.Map<RecommendationProductVm>(entiry);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            GenericDeleteCommand<StandardAutoresponderRecommendationProductEntity> command = new GenericDeleteCommand<StandardAutoresponderRecommendationProductEntity> { Id = id };
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
