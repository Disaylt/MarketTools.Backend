using MarketTools.Application.Common.Exceptions;
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
    public class AuthHelper(IUnitOfWork _unitOfWork) : IAuthReadHelper, IAuthWriteHelper
    {
        private IRepository<MarketplaceConnectionEntity> _connectionRepository = _unitOfWork.GetRepository<MarketplaceConnectionEntity>();
        private string? _userId;
        public string UserId
        {
            get
            {
                if(_userId == null)
                {
                    throw new IdentityUnauthorizedException("Не удалось получить ID пользователя.");
                }

                return _userId;
            }
        }

        public void Set(string userId)
        {
            _userId = userId;
        }

        public async Task SetByLoadConnectionAsync(int connectionId)
        {
            MarketplaceConnectionEntity entity = await _connectionRepository.FirstAsync(x=> x.Id == connectionId);
            _userId = entity.UserId;
        }
    }
}
