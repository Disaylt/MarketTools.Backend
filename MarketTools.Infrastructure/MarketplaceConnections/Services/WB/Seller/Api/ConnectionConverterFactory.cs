using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Services.WB.Seller.Api
{
    internal class WbSellerApiConnectionConverterFactory(IHttpConnectionContextService _httpConnectionContextService,
        IContextService<MarketplaceConnectionEntity> _contextService)
        : IConnectionConverterFactory<WbSellerApiConnectionConverter>
    {

        public WbSellerApiConnectionConverter Create(MarketplaceConnectionEntity connection)
        {
            return new WbSellerApiConnectionConverter(connection);
        }

        public WbSellerApiConnectionConverter CreateFromContext()
        {
            return new WbSellerApiConnectionConverter(_contextService.Context);
        }

        public WbSellerApiConnectionConverter CreateFromHttpContext()
        {
            return new WbSellerApiConnectionConverter(_httpConnectionContextService.GetRequired(MarketplaceName.WB, MarketplaceConnectionType.OpenApi));
        }
    }
}
