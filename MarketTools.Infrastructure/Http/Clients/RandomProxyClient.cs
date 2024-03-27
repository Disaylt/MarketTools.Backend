using MarketTools.Application.Interfaces.Http.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Clients
{
    internal class RandomProxyClient : IRandomProxyClient
    {
        private readonly HttpClient _httpClient;

        public RandomProxyClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            throw new NotImplementedException();
        }

        public void SetBaseUrl(string value)
        {
            throw new NotImplementedException();
        }
    }
}
