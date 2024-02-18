using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.Infrastructure.MarketplaceConnections.Providers;
using MarketTools.Infrastructure.MarketplaceConnections.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.ProjectServices.ServiceFactories
{
    internal class ServiceDeterminantFactory(IServiceProvider _serviceProvider) : IProjectServiceFactory<IConnectionDeterminantService>
    {
        private static Dictionary<EnumProjectServices, Func<IServiceProvider, IMarketplaceProvider<IConnectionDeterminantService>>> _projectServices =
            new Dictionary<EnumProjectServices, Func<IServiceProvider, IMarketplaceProvider<IConnectionDeterminantService>>>
            {
                {EnumProjectServices.StandardAutoresponder, x => x.GetRequiredService<WbServiceDeteminantProvider>()}
            };

        public IMarketplaceProvider<IConnectionDeterminantService> Create(EnumProjectServices projectService)
        {
            Func<IServiceProvider, IMarketplaceProvider<IConnectionDeterminantService>> func = _projectServices.GetValueOrDefault(projectService)
                ?? throw new AppNotFoundException($"Для сервиса {projectService} нет реализации.");

            return func.Invoke(_serviceProvider);
        }
    }
}
