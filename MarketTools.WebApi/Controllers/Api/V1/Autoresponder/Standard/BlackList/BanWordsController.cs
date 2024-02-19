using AutoMapper;
using MarketTools.Application.Requests.Autoresponder.Standard.BlackList.BanWords.Queries;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.Autoreponder.Standard.BlackList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard.BlackList
{
    [Route("api/v1/autoresponder/standard/black-list/ban-words")]
    [ApiController]
    [Authorize]
    public class BanWordsController(IMediator _mediator, IMapper _mapper)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(int blackListId)
        {
            BanWordGetRangeQuery query = new BanWordGetRangeQuery { BlackListId = blackListId };
            IEnumerable<StandardAutoresponderBanWordEntity> entities = await _mediator.Send(query);
            IEnumerable<BanWordVm> viewBanWords = _mapper.Map<IEnumerable<BanWordVm>>(entities);

            return Ok(viewBanWords);
        }
    }
}
