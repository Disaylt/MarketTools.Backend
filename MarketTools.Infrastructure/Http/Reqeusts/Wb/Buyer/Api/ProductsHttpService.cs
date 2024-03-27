using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Http.Clients;
using MarketTools.Application.Interfaces.Http.Wb.Buyer.Api.Products;
using MarketTools.Application.Models.Http.WB;
using MarketTools.Application.Models.Http.WB.Buyer.Api.Products;
using MarketTools.Infrastructure.Http.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Reqeusts.Wb.Buyer.Api
{
    internal class WbBuyerApiProductsHttpService : BaseHttpService, IWbBuyerApiProductsHttpService
    {
        private readonly IRandomProxyClient _randomProxyClient;
        private readonly IHttpQueryConverter<WbBuyerApiProductsRequestQuery> _httpQueryConverter;

        public WbBuyerApiProductsHttpService(IRandomProxyClient randomProxyClient, 
            IHttpQueryConverter<WbBuyerApiProductsRequestQuery> httpQueryConverter)
        {
            _randomProxyClient = randomProxyClient;
            _randomProxyClient.SetBaseUrl("https://card.wb.ru");
            _httpQueryConverter = httpQueryConverter;
        }

        public async Task<WbApiResult<WbBuyerApiProductsResponseData>> GetRange(WbBuyerApiProductsRequestQuery query)
        {
            string queirs = _httpQueryConverter.Convert(query);
            string path = $"cards/v2/detail?{queirs}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, path);
            HttpResponseMessage response = await _randomProxyClient.SendAsync(request);

            return await GetJsonResponseContentAsync<WbApiResult<WbBuyerApiProductsResponseData>>(response);
        }
    }
}
