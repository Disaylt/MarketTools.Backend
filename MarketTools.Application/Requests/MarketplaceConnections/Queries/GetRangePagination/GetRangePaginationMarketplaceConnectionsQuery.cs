using MarketTools.Application.Models.Requests;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Queries.GetRangePagination
{
    public class GetRangePaginationMarketplaceConnectionsQuery : GetRangeQuery<MarketplaceConnectionEntity>
    {
        public MarketplaceConnectionType ConnectionType { get; set; }
    }
}
