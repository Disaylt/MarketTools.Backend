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
    internal class ConnectionValidatorService(IProjectServiceFactory<IServiceValidator> _serviceValidatorFactory,
        IAuthUnitOfWork _authUnitOfWork)
        : IConnectionValidatorService
    {

        public async Task CheckServices(MarketplaceConnectionEntity entity)
        {
            if(entity.Id == 0)
            {
                return;
            }

            await CheckStandardAutoresponderAsync(entity);

            return;
        }

        private async Task CheckStandardAutoresponderAsync(MarketplaceConnectionEntity connection)
        {
            StandardAutoresponderConnectionEntity entity = await _authUnitOfWork
                .GetRepository<StandardAutoresponderConnectionEntity>()
                .FirstAsync(x => x.SellerConnectionId == connection.Id);

            if (entity.IsActive)
            {
                await _serviceValidatorFactory
                    .Create(EnumProjectServices.StandardAutoresponder, connection.MarketplaceName)
                    .TryActivete();
            }
        }
    }
}
