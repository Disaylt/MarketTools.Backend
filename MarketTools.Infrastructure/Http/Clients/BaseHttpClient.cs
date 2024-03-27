using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Clients
{
    internal class BaseHttpClient : IBaseHttpClient
    {
        protected HttpClient HttpClient { get; }

        public BaseHttpClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
            HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "PostmanRuntime/7.37.0");
        }

        public virtual async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            httpRequestMessage.Version = new Version(2, 0);
            HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage);

            if ((int)httpResponseMessage.StatusCode >= 400)
            {
                throw new AppBadRequestException("Ошибка HTTP запроса на сторонний сервер.");
            }

            return httpResponseMessage;
        }

        public virtual void SetBaseUrl(string value)
        {
            HttpClient.BaseAddress = new Uri(value);
        }
    }
}
