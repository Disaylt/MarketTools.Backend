using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Http.WB.Seller.Api.Feedbaks
{
    public class SendResponseBody
    {
        public required string Id { get; set; }
        public required string Text { get; set; }
    }
}
