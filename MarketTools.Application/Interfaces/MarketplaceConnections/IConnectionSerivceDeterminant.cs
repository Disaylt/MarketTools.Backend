using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Services;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.MarketplaceConnections
{
    public interface IConnectionSerivceDeterminant : IProjectService
    {
        public Task<MarketplaceConnectionEntity> GetAsync(IUnitOfWork unitOfWork, int id);
        public string Determinant();
    }
}
