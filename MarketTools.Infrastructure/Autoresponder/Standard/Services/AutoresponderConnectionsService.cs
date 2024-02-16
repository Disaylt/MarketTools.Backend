using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Autoresponder.Standard.Services
{
    internal class AutoresponderConnectionsService(IUnitOfWork _authUnitOfWork)
        : IAutoresponderConnectionsService
    {

        private readonly IRepository<StandardAutoresponderConnectionEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderConnectionEntity>();

        public async Task<IEnumerable<StandardAutoresponderConnectionEntity>> GetRangeForHandleAsync(MarketplaceName marketplaceName, CancellationToken cancellationToken = default)
        {
            return await _repository.GetRangeAsync(x => x.IsActive == true
                && x.SellerConnection.IsActive == true
                && x.SellerConnection.MarketplaceName == marketplaceName);
        }
    }
}
