using MarketTools.Domain.Interfaces.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Models
{
    internal class MarketplaceConnectionLimits : IMarketplaceConnectionLimits
    {
        public int MaxConnections { get; set; } = 250;
    }
}
