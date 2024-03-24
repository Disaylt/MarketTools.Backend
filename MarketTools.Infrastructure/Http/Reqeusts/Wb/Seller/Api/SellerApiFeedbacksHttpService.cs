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
using MarketTools.Infrastructure.Http.QueryBuilders.WB.Seller.Api.Feedbacks;
using System.Net.Http.Json;
using System.Text;

namespace MarketTools.Infrastructure.Http.Reqeusts.Wb.Seller.Api
{
    internal class SellerApiFeedbacksHttpService : BaseHttpService, IWbSellerApiFeedbacksService
    {
        private readonly IHttpConnectionClient _connectionClient;

        public SellerApiFeedbacksHttpService(IConnectionServiceFactory<IHttpConnectionClient> connectionClientFactory)
        {
            _connectionClient = connectionClientFactory.Create(MarketplaceConnectionType.OpenApi, MarketplaceName.WB);
            _connectionClient.HttpClient.BaseAddress = new Uri("https://feedbacks-api.wildberries.ru");
        }

        public async Task<WbApiResult<FeedbackResponseData>> GetFeedbacksAsync(FeedbacksQuery query)
        {
            string path = BuilUrlForGetFeedbacks(query);
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

        private string BuilUrlForGetFeedbacks(FeedbacksQuery data)
        {
            string query = new GetFeedbacksQueryBuilder()
                .IsAnswered(data.IsAnswered)
                .Sort(data.Order)
                .NmId(data.NmId)
                .DateFrom(data.DateFrom)
                .DateTo(data.DateTo)
                .Take(data.Take)
                .Skip(data.Skip)
                .Build();

            return "api/v1/feedbacks?" + query;
        }
    }
}
