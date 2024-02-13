using MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Commands.BindBlackList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard.Template
{
    [Route("api/v1/autoresponder/standard/template/black-list")]
    [ApiController]
    [Authorize]
    public class BlackListController(IMediator _mediator) : ControllerBase
    {
        [HttpPut]
        [Route("bind")]
        public async Task<IActionResult> BindBlackListAsync(int blackListId, int templateId)
        {
            BindBlackListCommand command = new BindBlackListCommand
            {
                BlackListId = blackListId,
                TemplateId = templateId
            };

            await _mediator.Send(command);

            return Ok();
        }
    }
}
