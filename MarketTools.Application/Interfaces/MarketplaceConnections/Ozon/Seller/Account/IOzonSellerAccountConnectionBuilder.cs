using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.MarketplaceConnections.Ozon.Seller.Account
{
    public interface IOzonSellerAccountConnectionBuilder : IConnectionBuilder
    {
        public IOzonSellerAccountConnectionBuilder SetAcceessToken(string token);
        public IOzonSellerAccountConnectionBuilder SetRefreshToken(string token);
        public IOzonSellerAccountConnectionBuilder SetSellerId(string sellerId);
    }
}
