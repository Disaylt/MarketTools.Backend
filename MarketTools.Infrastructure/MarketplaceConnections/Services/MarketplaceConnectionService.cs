using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Services
{
    internal class MarketplaceConnectionService(IUnitOfWork _unitOfWork)
        : IMarketplaceConnectionService
    {

        private readonly IRepository<MarketplaceConnectionEntity> _repository = _unitOfWork.GetRepository<MarketplaceConnectionEntity>();

        public Task<MarketplaceConnectionEntity> GetWithDetailsAsync(int connectionId)
        {
            return _repository.GetAsQueryable()
                .Include(x=> x.Cookies)
                .Include(x=> x.Headers)
                .AsSingleQuery()
                .FirstAsync(x=> x.Id == connectionId);
        }
    }
}
