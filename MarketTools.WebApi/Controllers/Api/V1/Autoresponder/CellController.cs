using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Cells.Commands.Create;
using MarketTools.Application.Cases.Autoresponder.Cells.Commands.Update;
using MarketTools.Application.Cases.Autoresponder.Cells.Models;
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
    public class CellController(IMediator _mediator,
        IMapper _mapper) 
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CellCreateDto body)
        {
            CreateCellCommand command = _mapper.Map<CreateCellCommand>(body);
            CellVm result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            DefaultDeleteCommand<AutoresponderCell> command = new DefaultDeleteCommand<AutoresponderCell> { Id = id };
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CellUpdateDto body)
        {
            UpdateCellCommand command = _mapper.Map<UpdateCellCommand>(body);
            CellVm result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
