using AutoMapper;
using MarketTools.Application.Cases.User.Command.Register;
using MarketTools.Application.Cases.User.Models;
using MarketTools.WebApi.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IdentityController(IMediator _mediator, IMapper _mapper) : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] NewUserDto newUser)
        {
            RegisterUserCommand command = _mapper.Map<RegisterUserCommand>(newUser);
            TokenVm token = await _mediator.Send(command);

            return Ok(token);
        }
    }
}
