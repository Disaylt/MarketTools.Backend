using AutoMapper;
using MarketTools.Application.Models.Commands;
using MarketTools.Application.Requests.Autoresponder.Standard.BlackList.BanWords.Commands.Add;
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
    public class BanWordController(IMediator _mediator, IMapper _mapper)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync(string value, int blackListId)
        {
            BanWordAddCommand command = new BanWordAddCommand
            {
                Value = value,
                BlackListId = blackListId
            };
            StandardAutoresponderBanWordEntity entity = await _mediator.Send(command);
            BanWordVm viewBanWord = _mapper.Map<BanWordVm>(entity);

            return Ok(viewBanWord);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            DefaultDeleteCommand<StandardAutoresponderBanWordEntity> command = new DefaultDeleteCommand<StandardAutoresponderBanWordEntity>
            {
                Id = id
            };
            await _mediator.Send(command);

            return Ok();
        }
    }
}
