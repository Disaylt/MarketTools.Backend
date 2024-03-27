using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Http.WB.Seller.Api.Prices
{
    public class PriceProductRequestQuery
    {
        public required int Take { get; set; }
        public int Skip { get; set; }
        public string? Article { get; set; }
    }
}
