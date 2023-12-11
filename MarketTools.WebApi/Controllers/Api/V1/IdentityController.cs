using AutoMapper;
using MarketTools.Application.Cases.User.Command.Login;
using MarketTools.Application.Cases.User.Command.Register;
using MarketTools.Application.Cases.User.Models;
using MarketTools.Application.Cases.User.Queries.GetUser;
using MarketTools.WebApi.Models.Api.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> RegisterAsync([FromBody] NewUserDto body)
        {
            RegisterUserCommand command = _mapper.Map<RegisterUserCommand>(body);
            TokenVm token = await _mediator.Send(command);

            return Ok(token);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAsync()
        {
            UserVm response = await _mediator.Send(new GetUserQuery());

            return Ok(response);
        }


        [HttpGet]
        [Route("is-auth")]
        public IActionResult IsAuth()
        {
            AuthCheckVm responseModel = new AuthCheckVm
            {
                IsAuth = User.Identity?.IsAuthenticated ?? false
            };

            return Ok(responseModel);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto body)
        {
            LoginUserCommand command = _mapper.Map<LoginUserCommand>(body);
            TokenVm token = await _mediator.Send(command);

            return Ok(token);
        }
    }
}
