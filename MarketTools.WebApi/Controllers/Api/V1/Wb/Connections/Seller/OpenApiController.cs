using AutoMapper;
using MarketTools.Application.Requests.Wb.Connections.Seller.OpenApi.Commands.Add;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.MarketplaceConnections;
using MarketTools.WebApi.Models.Api.WB.Connections.Seller;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Wb.Connections.Seller
{
    [Route("api/v1/wb/connections/seller/[controller]")]
    [ApiController]
    [Authorize]
    public class OpenApiController(IMediator _mediator, IMapper _mapper)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] NewOpenApiBody body)
        {
            SellerOpenApiAddCommand command = _mapper.Map<SellerOpenApiAddCommand>(body);

            MarketplaceConnectionEntity entitiy = await _mediator.Send(command);

            MarketplaceConnectionVm viewEntity = _mapper.Map<MarketplaceConnectionVm>(entitiy);

            return Ok(viewEntity);
        }
    }
}
