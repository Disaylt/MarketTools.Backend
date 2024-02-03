using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Wb.Seller.Api
{
    internal class WbOpenApiMessageHandler
        : BaseConnectionMessageHandler<MarketplaceConnectionOpenApiEntity>
    {
        public WbOpenApiMessageHandler(IHttpConnectionContextReader connectionContextReader) : base(connectionContextReader) { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionOpenApiEntity connection = ConnectionContextReader.Read<MarketplaceConnectionOpenApiEntity>();

            request.Headers.Add("Authorization", connection.Token);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
