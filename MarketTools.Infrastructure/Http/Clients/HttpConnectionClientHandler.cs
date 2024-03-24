using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Clients
{
    internal class HttpConnectionClientHandler : BaseHttpConnectionClient
    {
        protected SocketsHttpHandler ClientHandler { get; }
        private readonly ILogger<HttpConnectionClientHandler> _logger;

        public HttpConnectionClientHandler(IHttpConnectionContextService connectionContextReader, MarketplaceName marketplaceName, MarketplaceConnectionType type, ILogger<HttpConnectionClientHandler> logger) 
            : this(connectionContextReader, new SocketsHttpHandler(), marketplaceName, type, logger)
        {
           
        }

        private HttpConnectionClientHandler(IHttpConnectionContextService connectionContextReader, SocketsHttpHandler httpClientHandler, MarketplaceName marketplaceName, MarketplaceConnectionType type, ILogger<HttpConnectionClientHandler> logger)
            : base(connectionContextReader, new HttpClient(httpClientHandler), marketplaceName, type)
        {
            _logger = logger;
            ClientHandler = httpClientHandler;
            ClientHandler.AutomaticDecompression = ~DecompressionMethods.None;
            ClientHandler.UseCookies = true;
            ClientHandler.CookieContainer = new CookieContainer(200,100, 4000);
            SetCookies();
        }

        public override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            HttpResponseMessage response = await base.SendAsync(httpRequestMessage);
            _logger.LogInformation($"{httpRequestMessage.Method} '{httpRequestMessage.RequestUri}' | Response: {response.StatusCode}");

            return response;
        }

        private void SetCookies()
        {
            foreach(MarketplaceConnectionCookieEntity cookieEntity in Connection.Cookies)
            {
                Cookie cookie = new Cookie(cookieEntity.Name, cookieEntity.Value, cookieEntity.Path, cookieEntity.Domain);
                ClientHandler.CookieContainer.Add(cookie);
            }
        }
    }
}
