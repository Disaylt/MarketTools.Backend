using AutoMapper;
using MarketTools.Application.Requests.Identity.Commands;
using MarketTools.WebApi.Interfaces;
using MarketTools.WebApi.Models.Api.Identity;
using MarketTools.WebApi.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    
    public class IdentityController(IIdentityService _identityService, IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel body)
        {
            TokenVm token = await _identityService.RegisterAsync(body);

            return Ok(token);
        }

        [HttpPost]
        [Route("send-code")]
        [Authorize]
        public async Task<IActionResult> SendCodeAsync()
        {
            SendConfirmCodeCommand command = new SendConfirmCodeCommand();
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(PasswordRecoveryModel body)
        {
            TokenVm token = await _identityService.ResetPasswordAsync(body);

            return Ok(token);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAsync()
        {
            UserVm response = await _identityService.GetAuthUserAsync();

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
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel body)
        {
            TokenVm token = await _identityService.LoginAsync(body);

            return Ok(token);
        }
    }
}
