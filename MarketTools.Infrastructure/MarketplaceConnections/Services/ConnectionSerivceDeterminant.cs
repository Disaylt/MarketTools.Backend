using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Services
{
    internal class ConnectionSerivceDeterminant<T>()
        : IConnectionDeterminantService where T : MarketplaceConnectionEntity
    {
        public string Determinant()
        {
            return typeof(T).Name;
        }

        public async Task<MarketplaceConnectionEntity> GetAsync(IUnitOfWork unitOfWork, int id)
        {
            IRepository<T> repository = unitOfWork.GetRepository<T>();

            return await repository.FirstAsync(x => x.Id == id);
        }
    }
}
