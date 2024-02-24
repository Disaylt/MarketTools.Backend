using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Domain.Enums;
using MarketTools.Infrastructure.Autoresponder.Standard.Services;
using MarketTools.Infrastructure.MarketplaceConnections.Services.ConnectionDefinitions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Providers
{
    internal class WbConnectionDefinitionProvider : AbstractServiceProvider<IConnectionDefinitionService>
    {
        private static Dictionary<MarketplaceName, Func<IServiceProvider, IConnectionDefinitionService>> _providers =
            new Dictionary<MarketplaceName, Func<IServiceProvider, IConnectionDefinitionService>>
            {
                { MarketplaceName.WB, x=> x.GetRequiredService<WbStandardAutoresponderConnectionDifinitionService>() }
            };

        public WbConnectionDefinitionProvider(IServiceProvider serviceProvider) 
            : base(serviceProvider, _providers)
        {
        }
    }
}
