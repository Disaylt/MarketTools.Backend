using MarketTools.Application.Models.Http.WB;
using MarketTools.Application.Models.Http.WB.Seller.Api.Prices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http.Wb.Seller.Api
{
    public interface IWbSellerApiPriceHttpService
    {
        public Task<WbApiResult<PriceProductsResponseData>> GetRange(PriceProductRequestQuery query);
    }
}
