using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Clients
{
    internal abstract class BaseHttpConnectionClient : IHttpConnectionClient
    {
        protected MarketplaceConnectionEntity Connection { get; }
        public HttpClient HttpClient { get; }

        public BaseHttpConnectionClient(IHttpConnectionContextService connectionContextReader, HttpClient httpClient, MarketplaceName marketplaceName, MarketplaceConnectionType type)
        {
            Connection = connectionContextReader.GetRequired(marketplaceName, type);
            HttpClient = httpClient;
            foreach (var header in Connection.Headers)
            {
                HttpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Name, header.Value);
            }
            HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "PostmanRuntime/7.37.0");
        }

        public virtual async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            httpRequestMessage.Version = new Version(2, 0);
            HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage);

            if ((int)httpResponseMessage.StatusCode >= 400)
            {
                throw new AppConnectionBadRequestException(Connection, httpResponseMessage.StatusCode);
            }

            return httpResponseMessage;
        }
    }
}
