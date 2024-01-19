using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Requests;
using MarketTools.Application.Models.Requests;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.MarketplaceConnections
{
    public class MarketplaceConnectionsQueryFactory
    {
        public IGetRangePaginationQuery<MarketplaceConnectionEntity> CreateGetRangeQuery(MarketplaceConnectionType marketplaceConnectionType)
        {
            switch (marketplaceConnectionType)
            {
                case MarketplaceConnectionType.WbSellerOpenApi:
                    return new GetRangePaginationQuery<WbSellerOpenApiConnectionEntity>();
                default:
                    throw new AppNotFoundException("Такого типа подключения не существует.");
            }
        }
    }
}
