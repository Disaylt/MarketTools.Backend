using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Http.Wb.Seller;
using MarketTools.Application.Interfaces.Http.Wb.Seller.Api;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Models.Http.WB.Seller;
using MarketTools.Application.Models.Http.WB.Seller.Api;
using MarketTools.Application.Models.Http.WB.Seller.Api.Feedbacks;
using MarketTools.Domain.Enums;
using System.Net.Http.Json;
using System.Text;

namespace MarketTools.Infrastructure.Http.Reqeusts.Wb.Seller.Api
{
    internal class SellerApiFeedbacksHttpService : BaseHttpService, IWbSellerApiFeedbacksHttpService
    {
        private readonly IHttpConnectionClient _connectionClient;
        private readonly IHttpQueryConverter<WbSellerApiFeedbacksQuery> _httpQueryConverter;

        public SellerApiFeedbacksHttpService(IConnectionServiceFactory<IHttpConnectionClient> connectionClientFactory, 
            IHttpQueryConverter<WbSellerApiFeedbacksQuery> httpQueryConverter)
        {
            _connectionClient = connectionClientFactory.Create(MarketplaceConnectionType.OpenApi, MarketplaceName.WB);
            _connectionClient.HttpClient.BaseAddress = new Uri("https://feedbacks-api.wildberries.ru");
            _httpQueryConverter = httpQueryConverter;
        }

        public async Task<WbApiResult<FeedbackResponseData>> GetFeedbacksAsync(WbSellerApiFeedbacksQuery query)
        {
            string path = $"api/v1/feedbacks?{_httpQueryConverter.Convert(query)}";
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, path);

            HttpResponseMessage httpResponseMessage = await _connectionClient.SendAsync(requestMessage);

            return await GetJsonResponseContentAsync<WbApiResult<FeedbackResponseData>>(httpResponseMessage);
        }

        public async Task SendResponseAsync(ResponseBody body)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, "api/v1/feedbacks")
            {
                Content = JsonContent.Create(body)
            };

            await _connectionClient.SendAsync(request);
        }
    }
}
