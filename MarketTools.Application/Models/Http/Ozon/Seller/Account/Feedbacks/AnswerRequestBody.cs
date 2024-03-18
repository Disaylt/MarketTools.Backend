using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Http.Ozon.Seller.Account.Feedbacks
{
    public class AnswerRequestBody
    {
        [JsonPropertyName("company_id")]
        public required string CompanyId { get; set; }

        [JsonPropertyName("company_type")]
        public string CompanyType { get; set; } = "seller";

        [JsonPropertyName("review_uuid")]
        public required string ReviewUuid { get; set; }

        [JsonPropertyName("text")]
        public required string Text { get; set; }
    }
}
