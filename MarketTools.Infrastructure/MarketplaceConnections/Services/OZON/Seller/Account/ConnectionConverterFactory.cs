using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.MarketplaceConnections.Ozon.Seller.Account;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Services.OZON.Seller.Account
{
    internal class OzonSellerAccountConnectionConverterFactory(IHttpConnectionContextService _httpConnectionContextService,
        IContextService<MarketplaceConnectionEntity> _contextService) 
        : IConnectionConverterFactory<IOzonSellerAccountConnectionConverter>
    {
        public IOzonSellerAccountConnectionConverter Create(MarketplaceConnectionEntity connection)
        {
            return new OzonSellerAccountConnectionConverter(connection);
        }

        public IOzonSellerAccountConnectionConverter CreateFromContext()
        {
            return new OzonSellerAccountConnectionConverter(_contextService.Context);
        }

        public IOzonSellerAccountConnectionConverter CreateFromHttpContext()
        {
            return new OzonSellerAccountConnectionConverter(_httpConnectionContextService.GetRequired(MarketplaceName.OZON, MarketplaceConnectionType.Account));
        }
    }
}
