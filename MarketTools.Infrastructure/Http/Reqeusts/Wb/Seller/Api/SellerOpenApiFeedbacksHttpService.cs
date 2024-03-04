using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Http.Wb.Seller;
using MarketTools.Application.Models.Http.WB.Seller;
using MarketTools.Domain.Enums;
using MarketTools.Infrastructure.Http.Models.WB.Seller.Api;
using MarketTools.Infrastructure.Http.Models.WB.Seller.Api.Feedbacls;
using MarketTools.Infrastructure.Http.QueryBuilders.WB.Seller.Api.Feedbacks;
using System.Net.Http.Json;
using System.Text;

namespace MarketTools.Infrastructure.Http.Reqeusts.Wb.Seller.Api
{
    internal class SellerOpenApiFeedbacksHttpService : BaseHttpService, IWbSellerFeedbacksHttpService
    {
        private readonly IHttpConnectionClient _connectionClient;
        private readonly IMapper _mapper;

        public SellerOpenApiFeedbacksHttpService(IHttpConnectionClientFactory connectionClientFactory, IMapper mapper)
        {
            _mapper = mapper;
            _connectionClient = connectionClientFactory.Create(MarketplaceConnectionType.OpenApi, MarketplaceName.WB);
            _connectionClient.HttpClient.BaseAddress = new Uri("https://feedbacks-api.wildberries.ru");
        }

        public async Task<IEnumerable<FeedbackDto>> GetFeedbacksAsync(FeedbacksHttpRequestDto data)
        {
            string path = BuilUrlForGetFeedbacks(data);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, path);

            HttpResponseMessage httpResponseMessage = await _connectionClient.SendAsync(requestMessage);
            WbApiResult<FeedbackResponseData> responseContent = await GetJsonResponseContentAsync<WbApiResult<FeedbackResponseData>>(httpResponseMessage);

            return _mapper.Map<IEnumerable<FeedbackDto>>(responseContent.Data.Feedbacks);
        }

        public async Task SendResponseAsync(ResponseHttpRequestDto body)
        {
            string path = "";
            HttpContent content = JsonContent.Create(body);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, path);
            request.Content = content;

            await _connectionClient.SendAsync(request);
        }

        private string BuilUrlForGetFeedbacks(FeedbacksHttpRequestDto data)
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
