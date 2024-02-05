using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Services;
using MarketTools.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.ProjectServices
{
    internal class ProjectServiceProvider<T> : IProjectServiceProvider<T>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<EnumProjectServices, Func<IServiceProvider,T>> _projectServices;

        public ProjectServiceProvider(Dictionary<EnumProjectServices, Func<IServiceProvider,T>> projectServices, IServiceProvider serviceProvider)
        {
            _projectServices = projectServices;
            _serviceProvider = serviceProvider;
        }

        public virtual T Create(EnumProjectServices projectServices)
        {
            Func<IServiceProvider, T> func = _projectServices.GetValueOrDefault(projectServices)
                ?? throw new AppNotFoundException($"Для сервиса {projectServices} нет реализации.");

            return func.Invoke(_serviceProvider);
        }
    }
}
