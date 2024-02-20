using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Services
{
    internal class SelleOpenApiConnectionActivatorService : IConnectionActivatorService
    {

        public SelleOpenApiConnectionActivatorService()
        {

        }

        public async Task ActivateAsync(MarketplaceConnectionEntity entity)
        {
            //if (string.IsNullOrEmpty(entity.Token))
            //{
            //    entity.IsActive = false;
            //}
            //else if (entity.Id == 0)
            //{
            //    entity.IsActive = true;
            //}
            //else
            //{
            //    entity.IsActive = true;
            //}

            return;
        }
    }
}
