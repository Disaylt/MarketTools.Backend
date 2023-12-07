using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Columns.Commands.Create;
using MarketTools.Application.Cases.Autoresponder.Columns.Models;
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
    public class ColumnController(
        IMediator _mediator, 
        IMapper _mapper) 
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ColumnCreateDto body)
        {
            ColumnCreateCommand command = _mapper.Map<ColumnCreateCommand>(body);
            ColumnVm result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            DefaultDeleteCommand<AutoresponderColumn> command = new DefaultDeleteCommand<AutoresponderColumn> { Id = id };
            await _mediator.Send(command);

            return Ok();
        }
    }
}
