using MarketTools.Application.Interfaces.MarketplaceConnections.WB.Seller.Api;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Builders.WB.Seller.Api
{
    internal class WbSellerApiConnectionBuilder : ConnectionConverter, IWbSellerApiConnectionConverter
    {
        private const string _tokenHeaderName = "Authorization";
        public string? GetToken(MarketplaceConnectionEntity connection)
        {

            return connection
                .Headers
                .FirstOrDefault(x => x.Name == _tokenHeaderName)?
                .Value;
        }

        public IWbSellerApiConnectionConverter SetToken(string token)
        {
            AddOrUpdateHeader(_tokenHeaderName, token);

            return this;
        }
    }
}
