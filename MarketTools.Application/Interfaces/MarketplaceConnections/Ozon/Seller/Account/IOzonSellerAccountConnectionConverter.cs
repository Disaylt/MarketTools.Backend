using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.MarketplaceConnections.Ozon.Seller.Account
{
    public interface IOzonSellerAccountConnectionConverter : IConnectionConverter
    {
        public IOzonSellerAccountConnectionConverter SetAccessToken(string token);
        public IOzonSellerAccountConnectionConverter SetRefreshToken(string token);
        public IOzonSellerAccountConnectionConverter SetSellerId(string sellerId);
        public string? GetAccessToken(MarketplaceConnectionEntity connection);
        public string? GetRefreshToken(MarketplaceConnectionEntity connection);
        public string? GetSellerId(MarketplaceConnectionEntity connection);
    }
}
