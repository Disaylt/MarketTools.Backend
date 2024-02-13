using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Http.WB.Seller.Api.Feedbaks
{
    public class FeedbacksQuery
    {
        public required bool IsAnswered { get; set; }
        public required int Take { get; set; }
        public required int Skip { get; set; }
        public int? NmId { get; set; }
        public string Order { get; set; } = "dateDesc";
        public int? DateFrom { get; set; }
        public int? DateTo { get; set; }
    }
}
