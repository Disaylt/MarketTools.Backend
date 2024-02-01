﻿using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Services.MarketplaceConnecctions
{
    internal class WbSelleOpenApiConnectionActivator : IConnectionActivator<MarketplaceConnectionOpenApiEntity>
    {
        public Task ActivateAsync(MarketplaceConnectionOpenApiEntity entity)
        {
            if (string.IsNullOrEmpty(entity.Token))
            {
                entity.IsActive = false;
            }
            else if(entity.Id == 0)
            {
                entity.IsActive = true;
            }
            else
            {
                entity.IsActive = true;
            }

            return Task.CompletedTask;
        }
    }
}
