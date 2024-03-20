using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Models.Ozon.Seller.Account.Feedbacks
{
    public class FeedbacksRequestJsonBody
    {
        [JsonPropertyName("with_counters")]
        public bool WithCounters { get; set; } = false;

        [JsonPropertyName("sort")]
        public Sort Sort { get; set; } = new Sort();

        [JsonPropertyName("company_type")]
        public string CompanyType { get; set; } = "seller";

        [JsonPropertyName("filter")]
        public Filter Filter { get; set; } = new Filter();

        [JsonPropertyName("company_id")]
        public required string CompanyId { get; set; }

        [JsonPropertyName("pagination_last_timestamp")]
        public string? PaginationLastTimestamp { get; set; }

        [JsonPropertyName("pagination_last_uuid")]
        public string? PaginationLastUuid { get; set; }
    }

    public class Filter
    {
        [JsonPropertyName("rating")]
        public List<int> Rating { get; set; } = new List<int> { };

        [JsonPropertyName("interaction_status")]
        public List<string> InteractionStatus { get; set; } = new List<string>();
    }

    public class Sort
    {
        [JsonPropertyName("sort_by")]
        public string SortBy { get; set; } = "PUBLISHED_AT";

        [JsonPropertyName("sort_direction")]
        public string SortDirection { get; set; } = "DESC";
    }
}
