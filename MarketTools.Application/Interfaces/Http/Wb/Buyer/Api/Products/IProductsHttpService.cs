using MarketTools.Application.Models.Http.WB;
using MarketTools.Application.Models.Http.WB.Buyer.Api.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http.Wb.Buyer.Api.Products
{
    public interface IWbBuyerApiProductsHttpService
    {
        public Task<WbApiResult<WbBuyerApiProductsResponseData>> GetRange(WbBuyerApiProductsRequestQuery query);
    }
}
