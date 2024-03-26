using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Services
{
    internal class ConnectionDefinitionService : IConnectionDefinitionService
    {
        private static Dictionary<EnumProjectServices, Dictionary<MarketplaceName, MarketplaceConnectionType>> _connections =
            new Dictionary<EnumProjectServices, Dictionary<MarketplaceName, MarketplaceConnectionType>>
            {
                {EnumProjectServices.StandardAutoresponder, new Dictionary<MarketplaceName, MarketplaceConnectionType>
                    {
                        {MarketplaceName.WB, MarketplaceConnectionType.OpenApi },
                        {MarketplaceName.OZON, MarketplaceConnectionType.Account },
                    }
                },
                {EnumProjectServices.PriceMonitoring, new Dictionary<MarketplaceName, MarketplaceConnectionType>
                    {
                        {MarketplaceName.WB, MarketplaceConnectionType.OpenApi }
                    }
                }
            };

        public MarketplaceConnectionType Get(MarketplaceName marketplaceName, EnumProjectServices service)
        {
            return _connections
                .GetValueOrDefault(service)?
                .GetValueOrDefault(marketplaceName)
                ?? throw new AppBadRequestException("Сервис не поддерживается для данного маркетплейса.");
        }
    }
}
