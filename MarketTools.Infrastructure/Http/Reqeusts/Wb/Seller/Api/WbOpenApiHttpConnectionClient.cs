using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Reqeusts.Wb.Seller.Api
{
    internal class WbOpenApiHttpConnectionClient : BaseHttpConnectionClient
    {
        private readonly ApiConnectionDto _apiConnection;
        public WbOpenApiHttpConnectionClient(IContextService<MarketplaceConnectionEntity> connectionContextReader,
            IConnectionConverter<ApiConnectionDto> connectionConverter,
            HttpClient httpClient)
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
