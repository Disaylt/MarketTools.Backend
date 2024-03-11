using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Domain.Entities;

namespace MarketTools.Infrastructure.MarketplaceConnections.Services
{
    internal class ConnectionActivator(IProjectServiceFactory<IProjectServiceValidator> _projectServiceFactory, IAuthUnitOfWork _unitOfWork) : IConnectionActivator
    {
        public async Task ActivateAsync(MarketplaceConnectionEntity connection)
        {
            if(connection.Id != 0)
            {
                await TryActivateStandardAutoresponderAsync(connection);
            }

            connection.IsActive = true;
            connection.NumConnectionsAttempt = 0;
        }

        private async Task TryActivateStandardAutoresponderAsync(MarketplaceConnectionEntity connection)
        {
            StandardAutoresponderConnectionEntity entity = await _unitOfWork
                .GetRepository<StandardAutoresponderConnectionEntity>()
                .FirstAsync(x => x.SellerConnectionId == connection.Id);

            if(entity.IsActive == false)
            {
                return;
            }

            bool serviceActivated = await _projectServiceFactory
                    .Create(Domain.Enums.EnumProjectServices.StandardAutoresponder)
                    .TryActivate(connection);

            if(serviceActivated == false)
            {
                throw new AppBadRequestException("Не удалось выполнить подключение к стандартному автоответчику. Отключите сервис или используйте другие данные.");
            }
        }
    }
}
