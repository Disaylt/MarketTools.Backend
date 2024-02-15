using MarketTools.Application.Models.Requests;
using MarketTools.Application.Requests.MarketplaceConnections.Command;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.MarketplaceConnections
{
    [Route("api/v1/marketplace-connection")]
    [ApiController]
    [Authorize]
    public class MarketplaceConnectionController(IMediator _mediator) 
        : ControllerBase
    {
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            GenericDeleteCommand<MarketplaceConnectionEntity> command = new GenericDeleteCommand<MarketplaceConnectionEntity> { Id = id };

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        [Route("description")]
        public async Task<IActionResult> UpdateDescription([FromBody] ConnectionUpdateDescriptionCommand body)
        {
            await _mediator.Send(body);

            return Ok();
        }
    }
}
