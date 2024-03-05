using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Application.Interfaces.Services;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.ProjectServices.ServiceFactories
{
    internal class ProjectServiceFactory<T>(Dictionary<EnumProjectServices, Dictionary<MarketplaceName, Func<IServiceProvider, T>>> _servicesDictionary, IServiceProvider _serviceProvider)
        : IProjectServiceFactory<T> where T : class, IProjectService
    {
        public T Create(EnumProjectServices projectService, MarketplaceName marketplaceName)
        {
            var serviceCall = _servicesDictionary.GetValueOrDefault(projectService)?
                .GetValueOrDefault(marketplaceName)
                ?? throw new AppNotFoundException("Сервис не добавлен");

            return serviceCall.Invoke(_serviceProvider);
        }

        public T? CreateOrDefault(EnumProjectServices projectService, MarketplaceName marketplaceName)
        {
            var serviceCall = _servicesDictionary.GetValueOrDefault(projectService)?
                .GetValueOrDefault(marketplaceName);

            if(serviceCall == null)
            {
                return null;
            }

            return serviceCall.Invoke(_serviceProvider);
        }
    }
}
