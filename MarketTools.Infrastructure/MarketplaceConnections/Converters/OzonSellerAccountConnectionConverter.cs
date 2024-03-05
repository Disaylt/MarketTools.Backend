using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Converters
{
    internal class OzonSellerAccountConnectionConverter : IConnectionConverter<OzonSellerAccountConnectionDto>
    {
        public OzonSellerAccountConnectionDto Convert(MarketplaceConnectionEntity connection)
        {
            
        }

        public void SetDetails(MarketplaceConnectionEntity connection, OzonSellerAccountConnectionDto concreteConnection)
        {
            throw new NotImplementedException();
        }

        private MarketplaceConnectionCookieEntity GetRefreshToken(IEnumerable<MarketplaceConnectionCookieEntity> cookies)
        {
            return cookies.FirstOrDefault(x => x.Name == nameof(OzonSellerAccountConnectionDto.RefreshToken))
                ?? throw new AppNotFoundException("У подключения не установлен токен(Refresh).");
        }

        private MarketplaceConnectionCookieEntity? GetAccessToken(IEnumerable<MarketplaceConnectionCookieEntity> cookies)
        {
            return cookies.FirstOrDefault(x => x.Name == nameof(OzonSellerAccountConnectionDto.Token));
        }

        private MarketplaceConnectionCookieEntity GetSellerId(IEnumerable<MarketplaceConnectionCookieEntity> cookies)
        {
            return cookies.FirstOrDefault(x => x.Name == nameof(OzonSellerAccountConnectionDto.SellerId))
                ?? throw new AppNotFoundException("У подключения не установлен ID продовца.");
        }
    }
}
