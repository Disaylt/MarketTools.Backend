using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Application.Interfaces.Services;
using MarketTools.Domain.Enums;
using MarketTools.Infrastructure.Autoresponder.Standard.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Providers
{
    internal class WbServiceValidatorProvider: AvstractServiceProvider<IServiceValidator>, IMarketplaceProvider<IServiceValidator>
    {
        private static Dictionary<MarketplaceName, Func<IServiceProvider, IServiceValidator>> _providers =
            new Dictionary<MarketplaceName, Func<IServiceProvider, IServiceValidator>>
            {
                { MarketplaceName.WB, x=> x.GetRequiredService<WbStandardAutoresponderValidator>() }
            };

        public WbServiceValidatorProvider(IServiceProvider serviceProvider) : base(serviceProvider, _providers)
        {
        }
    }
}
