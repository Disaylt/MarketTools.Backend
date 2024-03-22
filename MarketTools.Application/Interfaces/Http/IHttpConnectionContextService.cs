using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http
{
    public interface IHttpConnectionContextService
    {
        public void Set(MarketplaceConnectionEntity connectionEntity);
        public MarketplaceConnectionEntity GetRequired(MarketplaceName marketplaceName, MarketplaceConnectionType type);
        public MarketplaceConnectionEntity? GetOrDefault(MarketplaceName marketplaceName, MarketplaceConnectionType type);
        public bool IsContains(int id);
    }
}
