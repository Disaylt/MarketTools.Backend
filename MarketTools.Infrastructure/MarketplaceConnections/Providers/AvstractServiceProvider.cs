using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Application.Interfaces.Services;
using MarketTools.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Providers
{
    internal class AvstractServiceProvider<T> : IMarketplaceProvider<T>
    {
        protected IServiceProvider ServiceProvider { get; }
        private readonly Dictionary<MarketplaceName, Func<IServiceProvider, T>> _providers;

        public AvstractServiceProvider(IServiceProvider serviceProvider, Dictionary<MarketplaceName, Func<IServiceProvider, T>> providers)
        {
            ServiceProvider = serviceProvider;
            _providers = providers;
        }

        public T Create(MarketplaceName marketplaceName)
        {
            Func<IServiceProvider, T> func = _providers.GetValueOrDefault(marketplaceName)
                ?? throw new AppNotFoundException($"Для сервиса {marketplaceName} нет реализации.");

            return func.Invoke(ServiceProvider);
        }
    }
}
