using MarketTools.Application.Interfaces.Http.Clients;
using MarketTools.Application.Interfaces.Http.Wb.Buyer.Api.Products;
using MarketTools.Application.Models.Http.WB;
using MarketTools.Application.Models.Http.WB.Buyer.Api.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Reqeusts.Wb.Buyer.Api
{
    internal class WbBuyerApiProductsHttpService : IWbBuyerApiProductsHttpService
    {
        private readonly IRandomProxyClient _randomProxyClient;
        private readonly 

        public Task<WbApiResult<WbBuyerApiProductsResponseData>> GetRange(WbBuyerApiProductsRequestQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
