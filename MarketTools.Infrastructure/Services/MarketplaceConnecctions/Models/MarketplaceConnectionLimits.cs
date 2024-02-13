using MarketTools.Domain.Interfaces.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Services.MarketplaceConnecctions.Models
{
    internal class MarketplaceConnectionLimits : IMarketplaceConnectionLimits
    {
        public int MaxConnections { get; set; } = 250;
    }
}
