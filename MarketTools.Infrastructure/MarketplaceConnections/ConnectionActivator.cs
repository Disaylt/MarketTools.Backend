using MarketTools.Application.Common.Exceptions;
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

namespace MarketTools.Infrastructure.MarketplaceConnections
{
    internal abstract class ConnectionActivator(IProjectServiceFactory<IServiceValidator> _connectionServiceFactory,
        IUnitOfWork _unitOfWork)
    {
        private readonly IRepository<StandardAutoresponderConnectionEntity> _standardAutoresponderConnectionRepository = _unitOfWork.GetRepository<StandardAutoresponderConnectionEntity>();

        protected async Task CheckServicesAsync(MarketplaceConnectionEntity marketplaceConnection)
        {
            await CheckStandardAutoresponderAsync(marketplaceConnection);
        }

        private async Task CheckStandardAutoresponderAsync(MarketplaceConnectionEntity marketplaceConnection)
        {
            try
            {
                StandardAutoresponderConnectionEntity connection = await _standardAutoresponderConnectionRepository
                .FirstAsync(x => x.SellerConnectionId == marketplaceConnection.Id);

                if (connection.IsActive)
                {
                    await _connectionServiceFactory
                        .Create(marketplaceConnection.MarketplaceName)
                        .Create(EnumProjectServices.StandardAutoresponder)
                        .TryActivete(marketplaceConnection.Id);
                }
            }
            catch (Exception ex)
            {
                throw new AppBadRequestException($"Ошибка при попытке подключения к стандартному автоответчику. Сообщение: {ex.Message}");
            }
        }
    }
}
