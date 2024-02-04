using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.MarketplaceConnections
{
    internal class MarketplaceConnectionFactory : IMarketplaceConnectionFactory
    {
        private readonly Dictionary<MarketplaceName, IServiceConnectionFactory> _connectionFactories;

        public MarketplaceConnectionFactory(Dictionary<MarketplaceName, IServiceConnectionFactory> connectionFactories)
        {
            _connectionFactories = connectionFactories;
        }

        public IServiceConnectionFactory Create(MarketplaceName marketplaceName)
        {
            return _connectionFactories.GetValueOrDefault(marketplaceName) 
                ?? throw new AppNotFoundException($"Для магазина {marketplaceName} нет определителя подключений.");
        }
    }
}
