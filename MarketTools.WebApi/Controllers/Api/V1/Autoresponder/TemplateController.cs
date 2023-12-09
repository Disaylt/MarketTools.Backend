using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Commands.Add;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Models;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Autoreponder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder
{
    [Route("api/v1/autoresponder/[controller]")]
    [ApiController]
    [Authorize]
    public class TemplateController(IMediator _mediator,
        IMapper _mapper) 
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TemplateCreateDto body, CancellationToken ct)
        {
            AddTemplateCommand command = _mapper.Map<AddTemplateCommand>(body);
            TemplateVm result = await _mediator.Send(command, ct);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken ct)
        {
            DefaultDeleteCommand<AutoresponderTemplate> command = new DefaultDeleteCommand<AutoresponderTemplate> { Id = id };
            await _mediator.Send(command, ct);

            return Ok();
        }
    }
}
