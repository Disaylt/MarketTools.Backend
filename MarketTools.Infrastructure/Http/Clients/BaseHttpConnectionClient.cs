using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Entities;
using MarketTools.Infrastructure.Http.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Clients
{
    internal abstract class BaseHttpConnectionClient : IHttpConnectionClient
    {
        protected MarketplaceConnectionEntity Connection { get; }
        public HttpClient HttpClient { get; }
        private readonly HttpConnectionClientOptions _options;

        public BaseHttpConnectionClient(IContextService<MarketplaceConnectionEntity> connectionContextReader, HttpClient httpClient, HttpConnectionClientOptions? options = null)
        {
            Connection = connectionContextReader.Context;
            HttpClient = httpClient;

            _options = options ?? new HttpConnectionClientOptions();
        }

        public virtual async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            foreach (var header in Connection.Headers)
            {
                httpRequestMessage.Headers.Add(header.Name, header.Value);
            }

            HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage);

            if ((int)httpResponseMessage.StatusCode >= 400 && _options.IsThrowBadRequestexception)
            {
                throw new AppConnectionBadRequestException(Connection, httpResponseMessage.StatusCode);
            }

            return httpResponseMessage;
        }
    }
}
