using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Http.Ozon.Seller.Account;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Models.Http.Ozon.Seller.Account.Feedbacks;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Reqeusts.Ozon.Seller.Account
{
    internal class OzonSellerAccountFeedbacksHttpService : BaseHttpService, IOzonSellerAccountFeedbacksHttpService
    {
        private readonly IHttpConnectionClient _connectionClient;
        private readonly IHttpContentConverter<FeedbacksRequestBody> _feedbacksRequestConverter;
        private readonly IHttpContentConverter<AnswerRequestBody> _answerRequestConverter;

        public OzonSellerAccountFeedbacksHttpService(IConnectionServiceFactory<IHttpConnectionClient> connectionClientFactory,
            IHttpContentConverter<FeedbacksRequestBody> feedbacksRequestConverter,
            IHttpContentConverter<AnswerRequestBody> answerRequestConverter)
        {
            _connectionClient = connectionClientFactory.Create(MarketplaceConnectionType.Account, MarketplaceName.OZON);
            _connectionClient.HttpClient.BaseAddress = new Uri("https://seller.ozon.ru");
            _feedbacksRequestConverter = feedbacksRequestConverter;
            _answerRequestConverter = answerRequestConverter;
        }

        public async Task<FeedbacksResponseBody> GetFeedbacksAsync(FeedbacksRequestBody body)
        {
            string path = "api/v3/review/list";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, path)
            {
                Content = _feedbacksRequestConverter.Convert(body)
            };

            HttpResponseMessage response = await _connectionClient.SendAsync(request);

            return await GetJsonResponseContentAsync<FeedbacksResponseBody>(response);
        }

        public async Task SendResponseAsync(AnswerRequestBody body)
        {
            string path = "api/review/comment/create";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, path)
            {
                Content = _answerRequestConverter.Convert(body)
            };

            await _connectionClient.SendAsync(request);
        }
    }
}
