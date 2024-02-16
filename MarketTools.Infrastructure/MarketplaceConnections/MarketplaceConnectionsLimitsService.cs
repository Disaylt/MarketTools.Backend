using MarketTools.Application.Interfaces.Common;
using MarketTools.Domain.Interfaces.Limits;
using MarketTools.Infrastructure.MarketplaceConnections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections
{
    internal class MarketplaceConnectionsLimitsService : ILimitsService<IMarketplaceConnectionLimits>
    {
        public Task<IMarketplaceConnectionLimits> GetAsync()
        {
            IMarketplaceConnectionLimits limits = new MarketplaceConnectionLimits();

            return Task.FromResult(limits);
        }
    }
}
