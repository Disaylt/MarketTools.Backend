using MarketTools.Application.Interfaces;
using MarketTools.Domain.Interfaces.Limits;
using MarketTools.Infrastructure.Services.MarketplaceConnecctions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Services.MarketplaceConnecctions
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
