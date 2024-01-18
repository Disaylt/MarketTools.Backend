using MarketTools.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Interfaces.Limits
{
    public interface IMarketplaceConnectionLimits : ILimitModel
    {
        public int MaxConnections { get; set; }
    }
}
