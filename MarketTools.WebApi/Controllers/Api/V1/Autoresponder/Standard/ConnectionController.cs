using MarketTools.Application.Requests.Autoresponder.Standard.Connections.Commands.UpdateStatus;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard
{
    [Route("api/v1/autoresponder/standard/[controller]")]
    [ApiController]
    [Authorize]
    public class ConnectionController(IMediator _mediator) : ControllerBase
    {
        [HttpPut]
        [Route("status")]
        public async Task<IActionResult> UpdateStatusAsync(int id, bool isActive)
        {
            UpdateConnenctionStatusCommand command = new UpdateConnenctionStatusCommand
            {
                Id = id,
                IsActive = isActive
            };

            await _mediator.Send(command);

            return Ok();
        }
    }
}
