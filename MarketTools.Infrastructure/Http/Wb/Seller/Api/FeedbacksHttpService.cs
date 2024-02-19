using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Http.Wb.Seller.Api;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.WB.Seller.Api;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Wb.Seller.Api
{
    internal class FeedbacksHttpService : WbOpenApiHttpConnectionService<MarketplaceConnectionOpenApiEntity>, IFeedbacksHttpService
    {
        private readonly HttpClient _httpClient; 

        public FeedbacksHttpService(HttpClient httpClient, IHttpConnectionContextService httpConnectionContextReader) : base(httpConnectionContextReader, httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://feedbacks-api.wildberries.ru");
        }

        public async Task<WbApiResult<FeedbackResponseData>> GetFeedbacksAsync(FeedbacksQuery query)
        {
            string path = CreatePathForGettingFeedbacks(query);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, path);

            HttpResponseMessage response = await SendAsync(requestMessage);

            return await response.Content
                .ReadFromJsonAsync<WbApiResult<FeedbackResponseData>>()
                ?? throw new AppBadRequestException("Не удалось прочитать json с отзывами WB");
        }

        public async Task SendResponseAsync(SendResponseBody body)
        {
            string path = "";
            HttpContent content = JsonContent.Create(body);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, path);
            request.Content = content;

            await SendAsync(request);
        }

        private string CreatePathForGettingFeedbacks(FeedbacksQuery query)
        {
            StringBuilder sb = new StringBuilder()
                .Append("api/v1/feedbacks?");

            List<string> requestParams = new List<string>
            {
                { $"isAnswered={query.IsAnswered}" },
                { $"take={query.Take}" },
                { $"skip={query.Skip}" },
                { $"order={query.Order}" }
            };
            
            if(query.NmId != null)
            {
                requestParams.Add($"nmId={query.NmId.Value}");
            }

            if(query.DateFrom != null)
            {
                requestParams.Add($"dateFrom={query.DateFrom.Value}");
            }

            if (query.DateTo != null)
            {
                requestParams.Add($"dateTo={query.DateTo.Value}");
            }

            sb.AppendJoin('&', requestParams);

            return sb.ToString();
        }
    }
}
