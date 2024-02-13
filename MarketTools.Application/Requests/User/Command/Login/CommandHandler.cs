using MarketTools.Application.Cases.User.Models;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.User.Command.Login
{
    public class CommandHandler(UserManager<AppIdentityUser> _userManager, ITokenService _tokenService) 
        : IRequestHandler<LoginUserCommand, TokenVm>
    {
        public async Task<TokenVm> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            AppIdentityUser user = await _userManager.FindByEmailAsync(request.Email)
                ?? throw new AppNotFoundException("Пользователь не найден.");

            if(await _userManager.CheckPasswordAsync(user, request.Password) is false)
            {
                throw new AppBadRequestException("Пароль не подходит.");
            }

            string token = _tokenService.Create(user);
            
            return new TokenVm { Token = token };
        }
    }
}
