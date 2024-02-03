using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http
{
    public class BaseConnectionMessageHandler<T>
        : DelegatingHandler
        where T : MarketplaceConnectionEntity
    {
        protected IHttpConnectionContextReader ConnectionContextReader { get; }

        public BaseConnectionMessageHandler(IHttpConnectionContextReader connectionContextReader)
        {
            ConnectionContextReader = connectionContextReader;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage httpResponseMessage = await base.SendAsync(request, cancellationToken);

            if ((int)httpResponseMessage.StatusCode >= 400)
            {
                throw new AppConnectionBadRequestException(ConnectionContextReader.Read<T>(), httpResponseMessage.StatusCode);
            }

            return httpResponseMessage;
        }
    }
}
