using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Http.WB.Seller.Api.Feedbacks
{
    public class WbSellerApiFeedbacksQuery
    {
        public required bool IsAnswered { get; set; }
        public required int Take { get; set; }
        public required int Skip { get; set; }
        public OrderType Order { get; set; }
        public int? NmId { get; set; }
        public long? DateFrom { get; set; }
        public long? DateTo { get; set; }
    }
}
