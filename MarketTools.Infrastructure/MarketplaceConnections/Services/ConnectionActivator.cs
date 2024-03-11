using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Services
{
    internal class ConnectionActivator(IProjectServiceFactory<IProjectServiceValidator> _projectServiceFactory, IAuthUnitOfWork _unitOfWork) : IConnectionActivator
    {
        public async Task ActivateAsync(MarketplaceConnectionEntity connection)
        {
            if(connection.Id == 0)
            {
                return;
            }

            await TryActivateStandardAutoresponderAsync(connection);
        }

        private async Task TryActivateStandardAutoresponderAsync(MarketplaceConnectionEntity connection)
        {
            StandardAutoresponderConnectionEntity entity = await _unitOfWork
                .GetRepository<StandardAutoresponderConnectionEntity>()
                .FirstAsync(x => x.SellerConnectionId == connection.Id);

            if(entity.IsActive)
            {
                await _projectServiceFactory
                    .Create(Domain.Enums.EnumProjectServices.StandardAutoresponder)
                    .TryActivate(connection);
            }
        }
    }
}
