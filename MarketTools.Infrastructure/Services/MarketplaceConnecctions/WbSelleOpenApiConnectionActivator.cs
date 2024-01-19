using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Services.MarketplaceConnecctions
{
    internal class WbSelleOpenApiConnectionActivator : IConnectionActivator<WbSellerOpenApiConnectionEntity>
    {
        public Task ActivateAsync(WbSellerOpenApiConnectionEntity entity)
        {
            if (string.IsNullOrEmpty(entity.Token))
            {
                entity.IsActive = false;
            }
            else if(entity.Id == 0)
            {
                entity.IsActive = true;
            }

            return Task.CompletedTask;
        }
    }
}
