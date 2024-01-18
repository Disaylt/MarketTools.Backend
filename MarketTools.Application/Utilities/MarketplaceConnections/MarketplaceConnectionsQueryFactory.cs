using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Models.Queries;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.MarketplaceConnections
{
    public class MarketplaceConnectionsQueryFactory
    {
        public GetRangeQuery<MarketplaceConnectionEntity> CreateGetRangeQuery(MarketplaceConnectionType marketplaceConnectionType)
        {
            switch (marketplaceConnectionType)
            {
                case MarketplaceConnectionType.WbSellerOpenApi:
                    return new GetRangeQuery<WbSellerOpenApiConnectionEntity>();
                default:
                    throw new AppNotFoundException("Такого типа подключения не существует.");
            }
        }
    }
}
