using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Models.WB.Seller.Api.Feedbacls
{
    internal class SendResponseBody
    {
        public required string Id { get; set; }
        public required string Text { get; set; }
    }
}
