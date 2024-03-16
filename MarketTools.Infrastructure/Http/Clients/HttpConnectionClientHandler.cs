using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
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

        public HttpConnectionClientHandler(IHttpConnectionContextService connectionContextReader, MarketplaceName marketplaceName, MarketplaceConnectionType type) 
            : this(connectionContextReader, new SocketsHttpHandler(), marketplaceName, type)
        {
            
        }

        private HttpConnectionClientHandler(IHttpConnectionContextService connectionContextReader, SocketsHttpHandler httpClientHandler, MarketplaceName marketplaceName, MarketplaceConnectionType type)
            : base(connectionContextReader, new HttpClient(httpClientHandler), marketplaceName, type)
        {
            ClientHandler = httpClientHandler;
            ClientHandler.AutomaticDecompression = ~DecompressionMethods.None;
            ClientHandler.UseCookies = true;
            ClientHandler.CookieContainer = new CookieContainer(200,100, 4000);
            SetCookies();
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
