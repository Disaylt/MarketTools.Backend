using AutoMapper;
using MarketTools.Application.Models.Requests;
using MarketTools.Application.Requests.Autoresponder.Standard.BlackList.Commands;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.Autoreponder.Standard;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard
{
    [Route("api/v1/autoresponder/standard/black-list")]
    [ApiController]
    [Authorize]
    public class BlackListController(IMediator _mediator, IMapper _mapper) 
        : ControllerBase
    {
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            GenericDeleteCommand<StandardAutoresponderBlackListEntity> command = new GenericDeleteCommand<StandardAutoresponderBlackListEntity> { Id = id };
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(string name)
        {
            BlackListAddCommand command = new BlackListAddCommand { Name = name };
            StandardAutoresponderBlackListEntity entity = await _mediator.Send(command);
            BlackListVm viewBlackList = _mapper.Map<BlackListVm>(entity);

            return Ok(viewBlackList);
        }
    }
}
