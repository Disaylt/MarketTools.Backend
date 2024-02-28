using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Http.Wb.Seller;
using MarketTools.Domain.Enums;
using MarketTools.Domain.Http.WB.Seller.Api;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;
using MarketTools.Domain.Interfaces.Http;
using System.Net.Http.Json;
using System.Text;

namespace MarketTools.Infrastructure.Http.Wb.Seller.Api
{
    internal class SellerOpenApiFeedbacksHttpService : IWbSellerFeedbacksHttpService
    {
        private readonly IHttpConnectionClient _connectionClient;

        public SellerOpenApiFeedbacksHttpService(IHttpConnectionClientFactory connectionClientFactory)
        {
            _connectionClient = connectionClientFactory.Create(MarketplaceConnectionType.OpenApi, MarketplaceName.WB);
            _connectionClient.HttpClient.BaseAddress = new Uri("https://feedbacks-api.wildberries.ru");
        }

        public async Task<HttpResponseMessage> GetFeedbacksAsync(IParamsBuilder paramsBuilder)
        {
            string path = $"api/v1/feedbacks?{paramsBuilder.Build()}";
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, path);

            return await _connectionClient.SendAsync(requestMessage);
        }

        public async Task<HttpResponseMessage> SendResponseAsync(SendResponseBody body)
        {
            string path = "";
            HttpContent content = JsonContent.Create(body);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, path);
            request.Content = content;

            return await _connectionClient.SendAsync(request);
        }
    }
}
