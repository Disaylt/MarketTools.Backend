using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Columns.Commands.Create;
using MarketTools.WebApi.Models.Autoreponder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder
{
    [Route("api/v1/autoresponder/[controller]")]
    [ApiController]
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
    }
}
