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
        public IServiceConnectionFactory Create(MarketplaceName marketplaceName)
        {
            switch(marketplaceName)
            {
                case MarketplaceName.WB:
                    return new WbServiceConnectionFactory();
            }

            throw new AppNotFoundException($"Для магазина {marketplaceName} нет определителя подключений.");
        }
    }
}
