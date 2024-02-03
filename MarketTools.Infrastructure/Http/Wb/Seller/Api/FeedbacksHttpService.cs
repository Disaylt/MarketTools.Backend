using MarketTools.Application.Interfaces.Http.Wb.Seller.Api;
using MarketTools.Domain.Http.WB.Seller.Api;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Wb.Seller.Api
{
    internal class FeedbacksHttpService : IFeedbacksHttpService
    {
        private readonly HttpClient _httpClient; 

        public FeedbacksHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://feedbacks-api.wildberries.ru");
        }

        public Task<WbApiResult<FeedbackResponseData>> GetFeedbacksAsync(FeedbacksQuery query)
        {
            throw new NotImplementedException();
        }

        public Task SendResponseAsync(SendResponseBody body)
        {
            throw new NotImplementedException();
        }
    }
}
