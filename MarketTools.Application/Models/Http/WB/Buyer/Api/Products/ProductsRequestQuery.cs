using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Http.WB.Buyer.Api.Products
{
    public class WbBuyerApiProductsRequestQuery
    {
        public List<string> Articles { get; } = new List<string>();
    }
}
