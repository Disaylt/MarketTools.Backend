using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Http.WB.Seller
{
    public class FeedbacksHttpRequestDto
    {
        public required bool IsAnswered { get; set; }
        public required int Take { get; set; }
        public required int Skip { get; set; }
        public OrderType Order { get; set; }
        public int? NmId { get; set; }
        public int? DateFrom { get; set; }
        public int? DateTo { get; set;}
    }
}
