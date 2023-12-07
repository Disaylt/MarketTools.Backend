using MarketTools.Application.Cases.User.Models;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.User.Command.Register
{
    internal class CommandHandler(UserManager<AppIdentityUser> _userManager, ITokenService _tokenService) : IRequestHandler<RegisterUserCommand, TokenVm>
    {

        public async Task<TokenVm> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            AppIdentityUser appIdentityUser = new AppIdentityUser
            {
                Email = request.Email,
                UserName = request.Email
            };

            await AddUserAsync(appIdentityUser, request.Password);

            return new TokenVm
            {
                Token = _tokenService.Create(appIdentityUser)
            };
        }

        private async Task AddUserAsync(AppIdentityUser appIdentityUser, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(appIdentityUser, password);

            if(result.Succeeded is false)
            {
                string errorMessage = result.Errors
                    .FirstOrDefault()?
                    .Description ?? "-";
                throw new DefaultBadRequestException(errorMessage);
            }
        }
    }
}
