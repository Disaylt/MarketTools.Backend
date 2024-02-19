using MarketTools.Application.Requests.Autoresponder.Standard.Connections.Commands;
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
        public async Task<IActionResult> UpdateStatusAsync([FromQuery] UpdateConnenctionStatusCommand httpQuery)
        {
            await _mediator.Send(httpQuery);

            return Ok();
        }
    }
}
