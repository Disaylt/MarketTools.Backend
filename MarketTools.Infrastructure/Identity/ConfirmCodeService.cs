using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Identity
{
    internal class ConfirmCodeService(IAuthUnitOfWork _authUnitOfWork) : IConfirmCodeService
    {
        private static readonly TimeSpan _awaitCreateTime = TimeSpan.FromMinutes(1);
        private static readonly TimeSpan _awaitCheckTime = TimeSpan.FromDays(1);
        private static readonly Random _random = new Random();
        public async Task<bool> CheckAsync(string code)
        {
            AppIdentityUser identity = await _authUnitOfWork
                .GetRepository<AppIdentityUser>()
                .FirstAsync();

            return Check(code, identity);
        }

        public bool Check(string code, AppIdentityUser user)
        {
            TimeSpan timeSinceLastCreation = DateTime.UtcNow - user.ConfirmationCodeCreateDate;

            return user.ConfirmationCode == code.Trim() && _awaitCheckTime > timeSinceLastCreation;
        }


        public async Task<string> CreateAsync()
        {
            IRepository<AppIdentityUser> repository = _authUnitOfWork.GetRepository<AppIdentityUser>();
            AppIdentityUser identity = await repository.FirstAsync();
            CheckCreateTime(identity);
            identity.ConfirmationCode = GenerateCode();
            identity.ConfirmationCodeCreateDate = DateTime.UtcNow;

            repository.Update(identity);
            await _authUnitOfWork.RollbackAsync();

            return identity.ConfirmationCode;
        }

        private string GenerateCode()
        {
            StringBuilder codeBuilder = new StringBuilder();
            for(int i =0; i < 6; i++)
            {
                codeBuilder.Append(_random.Next(10));
            }

            return codeBuilder.ToString();
        }

        private void CheckCreateTime(AppIdentityUser identity)
        {
            TimeSpan timeSinceLastCreation = DateTime.UtcNow - identity.ConfirmationCodeCreateDate;

            if(_awaitCreateTime > timeSinceLastCreation)
            {
                throw new AppBadRequestException("Необходимо подождать 1 минуту с предыдущей генерации кода.");
            }
        }
    }
}
