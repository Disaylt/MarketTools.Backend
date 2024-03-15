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
        public void Change(string sellerId, string refreshToken);
        public void Change(CookieContainer cookieContainer);
    }
}
