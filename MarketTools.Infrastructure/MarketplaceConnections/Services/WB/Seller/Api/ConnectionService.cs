using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.MarketplaceConnections.WB.Seller.Api;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Services.WB.Seller.Api
{
    internal class WbSellerApiConnectionService : BaseConnectionService, IWbSellerApiConnectionService
    {
        private const string _tokenHeaderKey = "Authorization";

        public WbSellerApiConnectionService(IContextService<MarketplaceConnectionEntity> contextService) : base(contextService)
        {
        }

        public void Change(string token)
        {
            AddOrUpdateHeader(_tokenHeaderKey, token);
        }
    }
}
