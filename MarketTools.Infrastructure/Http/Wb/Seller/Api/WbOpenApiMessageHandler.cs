using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Wb.Seller.Api
{
    internal class WbOpenApiMessageHandler(IHttpConnectionContextReader _connectionContextReader)
        : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionOpenApiEntity connection = _connectionContextReader.Read<MarketplaceConnectionOpenApiEntity>();

            request.Headers.Add("Authorization", connection.Token);

            HttpResponseMessage httpResponseMessage = await base.SendAsync(request, cancellationToken);

            if(httpResponseMessage != null)
            {

            }
        }
    }
}
