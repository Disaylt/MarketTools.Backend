﻿using AutoMapper;
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
    
    public class IdentityController(IIdentityService _identityService) : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel body)
        {
            TokenVm token = await _identityService.RegisterAsync(body);

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
