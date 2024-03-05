using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.MarketplaceConnections.WB.Seller.Api
{
    public interface IWbSellerApiConnectionBuilder : IConnectionBuilder
    {
        public IWbSellerApiConnectionBuilder SetToken(string token);
    }
}
