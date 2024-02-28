using ClosedXML.Excel;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http
{
    internal class HttpConnectionClientFactory(Dictionary<MarketplaceName, Dictionary<MarketplaceConnectionType, Func<IServiceProvider, IHttpConnectionClient>>> _connections, IServiceProvider _serviceProvider)
        : IHttpConnectionClientFactory
    {
        public IHttpConnectionClient Create(MarketplaceConnectionType type, MarketplaceName marketplaceName)
        {
            Func<IServiceProvider, IHttpConnectionClient> connectionCall = _connections
                .GetValueOrDefault(marketplaceName)?
                .GetValueOrDefault(type)
                ?? throw new AppNotFoundException("Такое подключение не добавлено.");

            return connectionCall.Invoke(_serviceProvider);
        }
    }
}
