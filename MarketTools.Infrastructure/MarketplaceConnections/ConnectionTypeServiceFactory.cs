using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections
{
    internal class ConnectionTypeServiceFactory<T>(Dictionary<MarketplaceConnectionType, Func<IServiceProvider, T>> _data, IServiceProvider _serviceProvider) 
        : IConnectionTypeServiceFactory<T>
    {
        public T Create(MarketplaceConnectionType type)
        {
            Func<IServiceProvider, T> serviceCall = _data
                .GetValueOrDefault(type)
                ?? throw new AppNotFoundException("Сервис не добавлен.");

            return serviceCall.Invoke(_serviceProvider);
        }
    }
}
