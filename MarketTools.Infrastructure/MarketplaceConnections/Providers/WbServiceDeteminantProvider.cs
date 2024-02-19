using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Application.Interfaces.Services;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.Infrastructure.Autoresponder.Standard.Services;
using MarketTools.Infrastructure.MarketplaceConnections.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Providers
{
    internal class WbServiceDeteminantProvider : AvstractServiceProvider<IConnectionDeterminantService>, IMarketplaceProvider<IConnectionDeterminantService>
    {
        private static Dictionary<MarketplaceName, Func<IServiceProvider, IConnectionDeterminantService>> _providers =
            new Dictionary<MarketplaceName, Func<IServiceProvider, IConnectionDeterminantService>>
            {
                { MarketplaceName.WB, x=> x.GetRequiredService<ConnectionSerivceDeterminant<MarketplaceConnectionOpenApiEntity>>() }
            };

        public WbServiceDeteminantProvider(IServiceProvider serviceProvider) : base(serviceProvider, _providers)
        {
        }
    }
}
