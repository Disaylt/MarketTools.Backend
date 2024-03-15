﻿using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.MarketplaceConnections.Ozon.Seller.Account;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Services.OZON.Seller.Account
{
    internal class OzonSellerAccountConnectionService : BaseConnectionService, IOzonSellerAccountConnectionService
    {
        private const string _cookieDomain = "ozon.ru";
        private const string _cookieNameRefreshToken = "__Secure-refresh-token";
        private const string _cookieNameSellerId = "contentId";

        public OzonSellerAccountConnectionService(IContextService<MarketplaceConnectionEntity> contextService) : base(contextService)
        {
        }

        public void ChangeAllCookies(CookieContainer cookieContainer)
        {
            CookieCollection cookies = cookieContainer.GetAllCookies();
            foreach(Cookie cookie in cookies)
            {
                if(IsNeedChange(cookie))
                {
                    AddOrUpdateCookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain);
                }
            }
        }

        public void ChangeRefreshToken(string refreshToken)
        {
            AddOrUpdateCookie(_cookieNameRefreshToken, refreshToken, "/", _cookieDomain);
        }

        public void ChangeSellerId(string sellerId)
        {
            AddOrUpdateCookie(_cookieNameSellerId, sellerId, "/", _cookieDomain);
        }

        public string GetSellerId()
        {
            return Connection
                .Cookies
                .FirstOrDefault(x => x.Name == _cookieNameSellerId && x.Domain == _cookieDomain)?
                .Value
                ?? throw new AppNotFoundException("Seller Id не найден.");
        }

        private bool IsNeedChange(Cookie cookie)
        {
            MarketplaceConnectionCookieEntity? cookieEntity = Connection
                .Cookies
                .FirstOrDefault(x => x.Name == cookie.Name && x.Domain == cookie.Domain);

            return cookieEntity == null || cookieEntity.Value != cookie.Value;
        }
    }
}