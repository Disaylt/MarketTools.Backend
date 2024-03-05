using MarketTools.Application.Interfaces.MarketplaceConnections.WB.Seller.Api;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Builders.WB.Seller.Api
{
    internal class WbSellerApiConnectionBuilder : IWbSellerApiConnectionBuilder
    {
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();
        public MarketplaceConnectionEntity Build(MarketplaceConnectionEntity connection)
        {


            return connection;
        }

        public IWbSellerApiConnectionBuilder SetToken(string token)
        {
            string name = "Authorization";

            if(_headers.ContainsKey(name))
            {
                _headers[name] = token;
            }
            else
            {
                _headers.Add(name, token);
            }

            return this;
        }
    }
}
