using AutoMapper;
using MarketTools.Application.Requests.MarketplaceConnections.Command.SellerOpenApi;
using MarketTools.Application.Requests.MarketplaceConnections.Command.WB.Seller.Api;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.MarketplaceConnections;
using MarketTools.WebApi.Models.Api.MarketplaceConnections.WB.Seller.Api;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.MarketplaceConnections.WB.Seller
{
    [Route("api/v1/connections/wb/seller/[controller]")]
    [ApiController]
    [Authorize]
    public class ApiController(IMediator _mediator, IMapper _mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] NewWbConnectionModel body)
        {
            AddWbSellerApiCommand command = _mapper.Map<AddWbSellerApiCommand>(body);

            MarketplaceConnectionEntity entity = await _mediator.Send(command);

            MarketplaceConnectionVm viewEntity = _mapper.Map<MarketplaceConnectionVm>(entity);

            return Ok(viewEntity);
        }

        [HttpPut]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshApiTokenModel body)
        {
            UpdateTokenSellerApiCommand command = _mapper.Map<UpdateTokenSellerApiCommand>(body);

            MarketplaceConnectionEntity entity = await _mediator.Send(command);

            MarketplaceConnectionVm viewEntity = _mapper.Map<MarketplaceConnectionVm>(entity);

            return Ok(viewEntity);
        }
    }
}
