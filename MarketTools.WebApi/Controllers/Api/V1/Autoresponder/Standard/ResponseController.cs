using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Requests.Autoresponder.Standard.Response.Command.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard
{
    [Route("api/v1/autoresponder/standard/[controller]")]
    [ApiController]
    [Authorize]
    public class ResponseController(IMediator _mediator)
        : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateResponseCommand body)
        {
            AutoresponderResultModel result = await _mediator.Send(body);

            return Ok(result);
        }
    }
}
