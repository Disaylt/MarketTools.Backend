using AutoMapper;
using MarketTools.Application.Requests.Autoresponder.Standard.BindPosition.Commands;
using MarketTools.Application.Requests.Autoresponder.Standard.BindPosition.Queries;
using MarketTools.Application.Requests.Autoresponder.Standard.ColumnBindPosition.Models;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.WebApi.Models.Api.Autoreponder.Standard;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard
{
    [Route("api/v1/autoresponder/standard/bind-positions")]
    [ApiController]
    [Authorize]
    public class BindPositionsController(IMediator _mediator, IMapper _mapper)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(AutoresponderColumnType columnType, int templateId)
        {
            BindPositionGetRangeQuery query = new BindPositionGetRangeQuery
            {
                TemplateId = templateId,
                ColumnType = columnType
            };

            IEnumerable<StandardAutoresponderBindPositionEntity> bindPositions = await _mediator.Send(query);
            IEnumerable<BindPostionVm> viewBindPosition = _mapper.Map<IEnumerable<BindPostionVm>>(bindPositions);

            return Ok(viewBindPosition);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRangeAsync([FromBody] IEnumerable<BindPositionDto> body, AutoresponderColumnType columnType, int templateId)
        {
            BindPositionUpdateRangeCommand command = new BindPositionUpdateRangeCommand
            {
                TemplateId = templateId,
                BindPositions = body,
                ColumnType = columnType
            };

            await _mediator.Send(command);

            return Ok();
        }
    }
}
