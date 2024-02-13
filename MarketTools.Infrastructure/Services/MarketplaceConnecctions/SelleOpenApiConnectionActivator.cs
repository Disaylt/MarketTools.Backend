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

namespace MarketTools.Infrastructure.Services.MarketplaceConnecctions
{
    internal class SelleOpenApiConnectionActivator
        : ConnectionActivator, IConnectionActivator<MarketplaceConnectionOpenApiEntity>
    {

        public SelleOpenApiConnectionActivator(IConnectionServiceFactory<IServiceValidator> connectionServiceFactory, IUnitOfWork unitOfWork)
            : base(connectionServiceFactory, unitOfWork)
        {

        }

        public async Task ActivateAsync(MarketplaceConnectionOpenApiEntity entity)
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
                await CheckServicesAsync(entity);
                entity.IsActive = true;
            }

            return;
        }
    }
}
