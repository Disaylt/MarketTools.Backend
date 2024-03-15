using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.MarketplaceConnections.Ozon.Seller.Account
{
    public interface IOzonSellerAccountConnectionService : IBaseConnectionService
    {
        public void ChangeSellerId(string sellerId);
        public void ChangeRefreshToken(string refreshToken);
        public void ChangeAllCookies(CookieContainer cookieContainer);
        public string GetSellerId();
    }
}
