using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Http.WB.Seller.Api.Feedbacks
{
    public class ResponseBody
    {
        public required string Id { get; set; }
        public required string Text { get; set; }
    }
}
