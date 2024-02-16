using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Models.Identity;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Identity
{
    internal class IdentityContextLoadService(IUnitOfWork _unitOfWork, IContextService<IdentityContext> _contextService)
        : IIdentityContextLoadService
    {
        private readonly IRepository<MarketplaceConnectionEntity> _repository = _unitOfWork.GetRepository<MarketplaceConnectionEntity>();
        public async Task LoadByConnection(int connectionId)
        {
            MarketplaceConnectionEntity entity = await _repository.FirstAsync(x=> x.Id == connectionId);

            _contextService.Context.UserId = entity.UserId;
        }
    }
}
