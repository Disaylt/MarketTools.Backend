using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.Services;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.MarketplaceConnections
{
    internal class ConnectionServiceFactory<T> : IProjectServiceFactory<T> where T : IProjectService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<MarketplaceName, Func<IServiceProvider, IMarketplaceProvider<T>>> _projectServiceProvider;

        public ConnectionServiceFactory(Dictionary<MarketplaceName, Func<IServiceProvider, IMarketplaceProvider<T>>> projectServiceProvider, IServiceProvider serviceProvider)
        {
            _projectServiceProvider = projectServiceProvider;
            _serviceProvider = serviceProvider;
        }

        public IMarketplaceProvider<T> Create(MarketplaceName marketplaceName)
        {
            return _projectServiceProvider.GetValueOrDefault(marketplaceName)?.Invoke(_serviceProvider)
                ?? throw new AppNotFoundException($"Для магазина {marketplaceName} нет подходящих сервисов.");
        }
    }
}
