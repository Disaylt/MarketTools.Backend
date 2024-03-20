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
        public required string CompanyId { get; set; }
        public OzonCompanyType CompanyType { get; set; }
        public required string ReviewUuid { get; set; }
        public required string Text { get; set; }
    }
}
