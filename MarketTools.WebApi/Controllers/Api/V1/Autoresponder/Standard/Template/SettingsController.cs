using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Settings.Commands.Update;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Settings.Models;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Settings.Queries.Get;
using MarketTools.WebApi.Models.Api.Autoreponder.Template;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard.Template
{
    [Route("api/v1/autoresponder/standard/template/[controller]")]
    [ApiController]
    [Authorize]
    public class SettingsController
        (IMediator _mediator,
        IMapper _mapper)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(int id)
        {
            GetCommand command = new GetCommand { TemplateId = id };
            SettingsVm result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] SettingsUpdateDto body)
        {
            UpdateCommand command = _mapper.Map<UpdateCommand>(body);
            await _mediator.Send(command);

            return Ok();
        }
    }
}
