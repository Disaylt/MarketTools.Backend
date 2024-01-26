using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Columns.Commands.Create;
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
    public class ColumnController(
        IMediator _mediator,
        IMapper _mapper)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ColumnCreateDto body, CancellationToken cancellationToken)
        {
            ColumnCreateCommand command = _mapper.Map<ColumnCreateCommand>(body);
            StandardAutoresponderColumnEntity newColumn = await _mediator.Send(command, cancellationToken);

            ColumnVm viewColumn = _mapper.Map<ColumnVm>(newColumn);

            return Ok(viewColumn);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            GenericDeleteCommand<StandardAutoresponderColumnEntity> command = new GenericDeleteCommand<StandardAutoresponderColumnEntity> { Id = id };
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }
    }
}
