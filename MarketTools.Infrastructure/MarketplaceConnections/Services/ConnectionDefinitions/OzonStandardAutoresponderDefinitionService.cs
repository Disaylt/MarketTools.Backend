using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Services.ConnectionDefinitions
{
    internal class OzonStandardAutoresponderDefinitionService : IConnectionDefinitionService
    {
        public MarketplaceConnectionType Get()
        {
            return MarketplaceConnectionType.Account;
        }
    }
}
