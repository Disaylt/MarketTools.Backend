using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Wb.Seller.Api
{
    internal class WbOpenApiHttpConnectionSender: BaseHttpConnectionSender<MarketplaceConnectionOpenApiEntity>
    {
        public WbOpenApiHttpConnectionSender(IHttpConnectionContextService connectionContextReader, HttpClient httpClient) : base(connectionContextReader, httpClient)
        {

        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            MarketplaceConnectionOpenApiEntity connection = ConnectionContextReader.Read<MarketplaceConnectionOpenApiEntity>();

            if (string.IsNullOrEmpty(connection.Token))
            {
                throw new AppBadRequestException("API токен для отправки запроса не назначен. Проверьте подключении к кабинету.");
            }

            httpRequestMessage.Headers.Add("Authorization", connection.Token);

            return base.SendAsync(httpRequestMessage);
        }
    }
}
