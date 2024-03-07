using ClosedXML.Excel;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections
{
    internal class ConnectionServiceFactory<T>(Dictionary<MarketplaceName, Dictionary<MarketplaceConnectionType, Func<IServiceProvider, T>>> _connections, IServiceProvider _serviceProvider)
        : IConnectionServiceFactory<T> where T : IConnectionService
    {
        public T Create(MarketplaceConnectionType type, MarketplaceName marketplaceName)
        {
            Func<IServiceProvider, T> connectionCall = _connections
                .GetValueOrDefault(marketplaceName)?
                .GetValueOrDefault(type)
                ?? throw new AppNotFoundException("Такое подключение не добавлено.");

            return connectionCall.Invoke(_serviceProvider);
        }
    }
}
