using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Http.WB.Seller.Api.Feedbaks
{
    public class FeedbackDetails
    {
        public required string Id { get; set; }
        public AnswerDetails? Answer { get; set; }
        public string Text { get; set; } = string.Empty;
        public required ProductDetails ProductDetails { get; set; }
        public int ProductValuation { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
