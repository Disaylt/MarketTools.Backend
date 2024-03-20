using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Http.Ozon.Seller.Account.Feedbacks
{
    public class FeedbacksRequestBody
    {
        public OzonCompanyType CompanyType { get; set; } 
        public required string CompanyId { get; set; }
        public string? PaginationLastTimestamp { get; set; }
        public string? PaginationLastUuid { get; set; }
        public SortBy SortBy { get; set; }
        public OrderType OrderType { get; set; } = OrderType.Desc;
        public List<int> Rating { get; set; } = new List<int>();
        public List<InteractionStatus> InteractionStatus { get; set; } = new List<InteractionStatus>();
    }
}
