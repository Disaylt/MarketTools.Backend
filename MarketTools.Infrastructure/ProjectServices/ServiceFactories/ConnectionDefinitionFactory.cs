using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Domain.Enums;
using MarketTools.Infrastructure.MarketplaceConnections.Providers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.ProjectServices.ServiceFactories
{
    internal class ConnectionDefinitionFactory : AbstractServiceFactory<IConnectionDefinitionService>
    {
        private static Dictionary<EnumProjectServices, Func<IServiceProvider, IMarketplaceProvider<IConnectionDefinitionService>>> _projectServices =
            new Dictionary<EnumProjectServices, Func<IServiceProvider, IMarketplaceProvider<IConnectionDefinitionService>>>
            {
                { EnumProjectServices.StandardAutoresponder, x=> x.GetRequiredService<WbConnectionDefinitionProvider>() }
            };

        public ConnectionDefinitionFactory(IServiceProvider serviceProvider) : base(serviceProvider, _projectServices)
        {
        }
    }
}
