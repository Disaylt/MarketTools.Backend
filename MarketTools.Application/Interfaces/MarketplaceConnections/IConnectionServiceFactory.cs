using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.MarketplaceConnections
{
    public interface IConnectionServiceFactory<T> where T : IConnectionService
    {
        public T Create(MarketplaceConnectionType type, MarketplaceName marketplaceName);
    }
}
