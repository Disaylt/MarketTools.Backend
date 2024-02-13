using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using MarketTools.Application.Cases.Autoresponder.Standard.Cells.Commands.Create;
using MarketTools.Application.Cases.Autoresponder.Standard.Cells.Commands.Update;
using MarketTools.Application.Models.Requests;
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
    public class CellController(IMediator _mediator,
        IMapper _mapper)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CellCreateDto body, CancellationToken cancellationToken)
        {
            CellCreateCommand command = _mapper.Map<CellCreateCommand>(body);
            StandardAutoresponderCellEntity newCell = await _mediator.Send(command, cancellationToken);

            CellVm cellVm = _mapper.Map<CellVm>(newCell);

            return Ok(cellVm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            GenericDeleteCommand<StandardAutoresponderCellEntity> command = new GenericDeleteCommand<StandardAutoresponderCellEntity> { Id = id };
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CellUpdateDto body, CancellationToken cancellationToken)
        {
            CellUpdateCommand command = _mapper.Map<CellUpdateCommand>(body);
            StandardAutoresponderCellEntity newCell = await _mediator.Send(command, cancellationToken);

            CellVm cellVm = _mapper.Map<CellVm>(newCell);

            return Ok(cellVm);
        }
    }
}
