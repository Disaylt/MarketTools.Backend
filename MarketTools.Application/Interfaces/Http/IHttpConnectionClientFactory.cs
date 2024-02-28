using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http
{
    public interface IHttpConnectionClientFactory
    {
        public IHttpConnectionClient Create(MarketplaceConnectionType type, MarketplaceName marketplaceName);
    }
}
