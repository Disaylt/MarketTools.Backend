using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Cells.Commands.Create;
using MarketTools.Application.Cases.Autoresponder.Cells.Commands.Update;
using MarketTools.Application.Cases.Autoresponder.Cells.Models;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.Autoreponder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder
{
    [Route("api/v1/autoresponder/[controller]")]
    [ApiController]
    [Authorize]
    public class CellController(IMediator _mediator,
        IMapper _mapper) 
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CellCreateDto body, CancellationToken cancellationToken)
        {
            CreateCommand command = _mapper.Map<CreateCommand>(body);
            CellVm result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            DefaultDeleteCommand<AutoresponderStandardCell> command = new DefaultDeleteCommand<AutoresponderStandardCell> { Id = id };
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CellUpdateDto body, CancellationToken cancellationToken)
        {
            UpdateCommand command = _mapper.Map<UpdateCommand>(body);
            CellVm result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}
