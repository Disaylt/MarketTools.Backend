using MarketTools.Application.Interfaces.MarketplaceConnections.WB.Seller.Api;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Builders.WB.Seller.Api
{
    internal class WbSellerApiConnectionBuilder : ConnectionBuilder, IWbSellerApiConnectionBuilder
    {
        public IWbSellerApiConnectionBuilder SetToken(string token)
        {
            string name = "Authorization";
            AddOrUpdateHeader(name, token);

            return this;
        }
    }
}
