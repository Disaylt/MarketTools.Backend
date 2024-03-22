using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Identity
{
    internal class ConfirmCodeService(IAuthUnitOfWork _authUnitOfWork) : IConfirmCodeService
    {
        private readonly IRepository<AppIdentityUser> _reporitory = _authUnitOfWork.GetRepository<AppIdentityUser>();
        public Task<bool> CheckAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateAsync()
        {
            _reporitory.FirstAsync();
            throw new NotImplementedException();
        }
    }
}
