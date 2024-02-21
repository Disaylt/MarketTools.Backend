using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Wb.Seller.Api
{
    internal class WbOpenApiHttpConnectionSender : BaseHttpConnectionSender
    {
        private readonly ApiConnectionDto _apiConnection;
        public WbOpenApiHttpConnectionSender(IContextService<MarketplaceConnectionEntity> connectionContextReader, 
            HttpClient httpClient,
            IConnectionConverter<ApiConnectionDto> connectionConverter) 
            : base(connectionContextReader, httpClient)
        {
            _apiConnection = connectionConverter.Convert(Connection);
        }

        public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            if (string.IsNullOrEmpty(_apiConnection.Token))
            {
                throw new AppBadRequestException("API токен для отправки запроса не назначен. Проверьте подключении к кабинету.");
            }

            httpRequestMessage.Headers.Add("Authorization", _apiConnection.Token);

            return base.SendAsync(httpRequestMessage);
        }
    }
}
