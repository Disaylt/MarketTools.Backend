using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Clients
{
    internal class WbOpenApiHttpConnectionClient : BaseHttpConnectionClient
    {
        public WbOpenApiHttpConnectionClient(IHttpConnectionContextService connectionContextReader,
            HttpClient httpClient)
            : base(connectionContextReader, httpClient, MarketplaceName.WB, MarketplaceConnectionType.OpenApi)
        {

        }
    }
}
