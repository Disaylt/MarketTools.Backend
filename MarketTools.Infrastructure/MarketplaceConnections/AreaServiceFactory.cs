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
    internal class AreaServiceFactory<T>(Dictionary<MarketplaceName, Func<IServiceProvider, T>> _data, IServiceProvider _serviceProvider)
        : IAreaServiceFactory<T>
    {
        public T Create(MarketplaceName marketplaceName)
        {
            Func<IServiceProvider, T> serviceCall = _data
                .GetValueOrDefault(marketplaceName)
                ?? throw new AppNotFoundException("Сервис не добавлен.");

            return serviceCall.Invoke(_serviceProvider);
        }
    }
}
