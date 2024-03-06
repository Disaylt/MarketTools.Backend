using AutoMapper;
using MarketTools.Application.Requests.MarketplaceConnections.Command.Ozon.Seller.Account;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.MarketplaceConnections;
using MarketTools.WebApi.Models.Api.MarketplaceConnections.Ozon.Seller.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.MarketplaceConnections.Ozon.Seller
{
    [Route("api/v1/connections/ozon/seller/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController(IMediator _mediator, IMapper _mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] NewOzonConnectionModel body)
        {
            AddOzonSellerAccountCommand command = _mapper.Map<AddOzonSellerAccountCommand>(body);

            MarketplaceConnectionEntity entity = await _mediator.Send(command);

            MarketplaceConnectionVm viewEntity = _mapper.Map<MarketplaceConnectionVm>(entity);

            return Ok(viewEntity);
        }

        [HttpPut]
        [Route("refresh-token")]
        public async Task<IActionResult> UpdateRefreshTokenAsync([FromBody] UpdateRefreshTokenModel body)
        {
            UpdateRefreshTokenSellerAccountCommand command = _mapper.Map<UpdateRefreshTokenSellerAccountCommand>(body);

            MarketplaceConnectionEntity entity = await _mediator.Send(command);

            MarketplaceConnectionVm viewEntity = _mapper.Map<MarketplaceConnectionVm>(entity);

            return Ok(viewEntity);
        }
    }
}
