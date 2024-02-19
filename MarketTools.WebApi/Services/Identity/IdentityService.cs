using AutoMapper;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Models.Identity;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Interfaces;
using MarketTools.WebApi.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace MarketTools.WebApi.Services.Identity
{
    public class IdentityService(UserManager<AppIdentityUser> _userManager, ITokenService _tokenService, IMapper _mapper, IContextService<IdentityContext> _identityContext)
        : IIdentityService
    {
        public async Task<UserVm> GetAuthUserAsync()
        {
            AppIdentityUser appIdentityUser = await _userManager.FindByIdAsync(_identityContext.Context.UserId)
                ?? throw new AppNotFoundException();

            UserVm userVm = _mapper.Map<UserVm>(appIdentityUser);

            return userVm;
        }

        public async Task<TokenVm> LoginAsync(LoginModel login)
        {
            AppIdentityUser user = await _userManager.FindByEmailAsync(login.Email)
                ?? throw new AppNotFoundException("Пользователь не найден.");

            if (await _userManager.CheckPasswordAsync(user, login.Password) is false)
            {
                throw new AppBadRequestException("Пароль не подходит.");
            }

            string token = _tokenService.Create(user);

            return new TokenVm { Token = token };
        }

        public async Task<TokenVm> RegisterAsync(RegisterModel register)
        {
            ValidatePasswords(register.Password, register.RepeatPassword);

            AppIdentityUser appIdentityUser = new AppIdentityUser
            {
                Email = register.Email,
                UserName = register.UserName
            };

            await AddUserAsync(appIdentityUser, register.Password);

            return new TokenVm
            {
                Token = _tokenService.Create(appIdentityUser)
            };
        }

        private void ValidatePasswords(string password, string repeatPassword)
        {
            if(password != repeatPassword)
            {
                throw new AppBadRequestException("Пароли не совпадают");
            }
        }

        private async Task AddUserAsync(AppIdentityUser appIdentityUser, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(appIdentityUser, password);

            if (result.Succeeded is false)
            {
                string errorMessage = result.Errors
                    .FirstOrDefault()?
                    .Description ?? "-";
                throw new AppBadRequestException(errorMessage);
            }
        }
    }
}
