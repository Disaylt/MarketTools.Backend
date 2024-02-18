using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.Services;
using MarketTools.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.ProjectServices.ServiceFactories
{
    internal abstract class AbstractServiceFactory<T> : IProjectServiceFactory<T> where T : IProjectService
    {
        protected IServiceProvider ServiceProvider { get; }
        private readonly Dictionary<EnumProjectServices, Func<IServiceProvider, IMarketplaceProvider<T>>> _projectServices;

        public AbstractServiceFactory(IServiceProvider serviceProvider, Dictionary<EnumProjectServices, Func<IServiceProvider, IMarketplaceProvider<T>>> projectServices)
        {
            ServiceProvider = serviceProvider;
            _projectServices = projectServices;
        }

        public virtual IMarketplaceProvider<T> Create(EnumProjectServices projectService)
        {
            Func<IServiceProvider, IMarketplaceProvider<T>> func = _projectServices.GetValueOrDefault(projectService)
                ?? throw new AppNotFoundException($"Для сервиса {projectService} нет реализации.");

            return func.Invoke(ServiceProvider);
        }
    }
}
