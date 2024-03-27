using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Http.Wb.Seller.Api;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Models.Http.WB.Seller.Api;
using MarketTools.Application.Models.Http.WB.Seller.Api.Prices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Reqeusts.Wb.Seller.Api
{
    internal class WbSellerApiPricesHttpService : BaseHttpService, IWbSellerApiPriceHttpService
    {
        private readonly IHttpConnectionClient _connectionClient;
        private readonly IHttpQueryConverter<PriceProductRequestQuery> _httpQueryConverter;

        public WbSellerApiPricesHttpService(IConnectionServiceFactory<IHttpConnectionClient> connectionClientFactory, 
            IHttpQueryConverter<PriceProductRequestQuery> httpQueryConverter)
        {
            _connectionClient = connectionClientFactory.Create(Domain.Enums.MarketplaceConnectionType.OpenApi, Domain.Enums.MarketplaceName.WB);
            _connectionClient.HttpClient.BaseAddress = new Uri("https://discounts-prices-api.wb.ru");
            _httpQueryConverter = httpQueryConverter;
        }

        public async Task<WbApiResult<PriceProductsResponseData>> GetRange(PriceProductRequestQuery query)
        {
            string path = $"api/v2/list/goods/filter?{_httpQueryConverter.Convert}";
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, path);
            HttpResponseMessage response = await _connectionClient.SendAsync(httpRequestMessage);

            return await GetJsonResponseContentAsync<WbApiResult<PriceProductsResponseData>>(response);
        }
    }
}
