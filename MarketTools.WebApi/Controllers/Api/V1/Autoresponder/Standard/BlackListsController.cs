using AutoMapper;
using MarketTools.Application.Requests.Autoresponder.Standard.BlackList.Queries.GetRange;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.Autoreponder.Standard;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard
{
    [Route("api/v1/autoresponder/standard/black-lists")]
    [ApiController]
    [Authorize]
    public class BlackListsController(IMediator _mediator, IMapper _mapper)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRangeAsync()
        {
            BlackListGetRangeQuery query = new BlackListGetRangeQuery { };
            IEnumerable<StandardAutoresponderBlackListEntity> entities = await _mediator.Send(query);
            IEnumerable<BlackListVm> viewBlackLists = _mapper.Map<IEnumerable<BlackListVm>>(entities);

            return Ok(viewBlackLists);
        }
    }
}
