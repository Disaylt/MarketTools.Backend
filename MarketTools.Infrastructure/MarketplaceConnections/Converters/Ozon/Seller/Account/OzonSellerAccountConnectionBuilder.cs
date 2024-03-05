using MarketTools.Application.Interfaces.MarketplaceConnections.Ozon.Seller.Account;
using MarketTools.Domain.Entities;
using MarketTools.Infrastructure.MarketplaceConnections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Builders.Ozon.Seller.Account
{
    internal class OzonSellerAccountConnectionBuilder : ConnectionConverter, IOzonSellerAccountConnectionConverter
    {
        private const string _domain = "ozon.ru";
        private const string _accessTokenName = "__Secure-access-token";
        private const string _refreshTokenName = "__Secure-refresh-token";
        private const string _sellerIdName = "sellerId";
        public string? GetAccessToken(MarketplaceConnectionEntity connection)
        {
            return connection
                .Cookies
                .FirstOrDefault(x => x.Name == _accessTokenName && x.Domain == _domain)?
                .Value;
        }

        public string? GetRefreshToken(MarketplaceConnectionEntity connection)
        {
            return connection
               .Cookies
               .FirstOrDefault(x => x.Name == _refreshTokenName && x.Domain == _domain)?
               .Value;
        }

        public string? GetSellerId(MarketplaceConnectionEntity connection)
        {
            return connection
                .Headers
                .FirstOrDefault(x => x.Name == _sellerIdName)?
                .Value;
        }

        public IOzonSellerAccountConnectionConverter SetAccessToken(string token)
        {
            CookieModel cookie = new CookieModel
            {
                Domain = _domain,
                Name = _accessTokenName,
                Path = "/",
                Value = token
            };
            AddOrUpdateCookie(cookie);

            return this;
        }

        public IOzonSellerAccountConnectionConverter SetRefreshToken(string token)
        {
            CookieModel cookie = new CookieModel
            {
                Domain = _domain,
                Name = _refreshTokenName,
                Path = "/",
                Value = token
            };
            AddOrUpdateCookie(cookie);

            return this;
        }

        public IOzonSellerAccountConnectionConverter SetSellerId(string sellerId)
        {
            AddOrUpdateHeader(_sellerIdName, sellerId);

            return this;
        }
    }
}
