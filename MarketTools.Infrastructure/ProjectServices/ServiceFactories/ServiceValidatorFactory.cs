using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Application.Interfaces.Services;
using MarketTools.Domain.Enums;
using MarketTools.Infrastructure.Autoresponder.Standard.Services;
using MarketTools.Infrastructure.MarketplaceConnections.Providers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.ProjectServices.ServiceFactories
{
    internal class ServiceValidatorFactory(IServiceProvider _serviceProvider) : IProjectServiceFactory<IServiceValidator>
    {
        private static Dictionary<EnumProjectServices, Func<IServiceProvider, IMarketplaceProvider<IServiceValidator>>> _projectServices =
            new Dictionary<EnumProjectServices, Func<IServiceProvider, IMarketplaceProvider<IServiceValidator>>>
            {
                { EnumProjectServices.StandardAutoresponder, x=> x.GetRequiredService<WbServiceValidatorProvider>() }
            };

        public IMarketplaceProvider<IServiceValidator> Create(EnumProjectServices projectService)
        {
            Func<IServiceProvider, IMarketplaceProvider<IServiceValidator>> func = _projectServices.GetValueOrDefault(projectService)
                ?? throw new AppNotFoundException($"Для сервиса {projectService} нет реализации.");

            return func.Invoke(_serviceProvider);
        }
    }
}
