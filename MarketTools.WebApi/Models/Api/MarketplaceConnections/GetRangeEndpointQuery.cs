using MarketTools.Domain.Common;
using MarketTools.Domain.Enums;

namespace MarketTools.WebApi.Models.Api.MarketplaceConnections
{
    public class GetRangeEndpointQuery : PaginationModel
    {
        public MarketplaceConnectionType ConnectionType { get; set; }
    }
}
