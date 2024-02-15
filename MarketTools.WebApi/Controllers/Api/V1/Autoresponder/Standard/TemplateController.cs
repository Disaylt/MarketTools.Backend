using AutoMapper;
using MarketTools.Application.Models.Requests;
using MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Commands;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.Autoreponder.Standard;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard
{
    [Route("api/v1/autoresponder/standard/[controller]")]
    [ApiController]
    [Authorize]
    public class TemplateController(IMediator _mediator,
        IMapper _mapper)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TemplateCreateDto body, CancellationToken ct)
        {
            TemplateAddCommand command = _mapper.Map<TemplateAddCommand>(body);
            StandardAutoresponderTemplateEntity template = await _mediator.Send(command, ct);

            TemplateVm viewTemplate = _mapper.Map<TemplateVm>(template);

            return Ok(viewTemplate);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken ct)
        {
            GenericDeleteCommand<StandardAutoresponderTemplateEntity> command = new GenericDeleteCommand<StandardAutoresponderTemplateEntity> { Id = id };
            await _mediator.Send(command, ct);

            return Ok();
        }
    }
}
