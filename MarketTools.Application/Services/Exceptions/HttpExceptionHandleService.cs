using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Application.Utilities.ProjectServices;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MarketTools.Application.Services.Exceptions
{
    internal class HttpExceptionHandleService(IUserNotificationsService _userNotificationsService, IAuthUnitOfWork _authUnitOfWork)
        : IExceptionHandleService<AppConnectionBadRequestException>
    {
        private static int _maxNumErrors = 3;
        private readonly IRepository<MarketplaceConnectionEntity> _repository = _authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();

        public async Task Hadnle(AppConnectionBadRequestException exeption)
        {
            if (exeption.HttpStatusCode == HttpStatusCode.TooManyRequests) return;

            UseAttemptCounter(exeption.MarketplaceConnection);
            UseActivateStatusHandler(exeption);
            await UseNotificationCreatorAsync(exeption);

            _repository.Update(exeption.MarketplaceConnection);
            await _authUnitOfWork.CommitAsync();
        }

        private async Task UseNotificationCreatorAsync(AppConnectionBadRequestException exeption)
        {
            if(exeption.MarketplaceConnection.IsActive) return;

            MarketplaceConnectionEntity connection = exeption.MarketplaceConnection;
            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.AppendLine($"Подключение '{connection.Name}' | id: {connection.Id} не установило подключение к серверу после '{connection.NumConnectionsAttempt}' попыток. " +
                $"Пожалуйста, обновите данные подключения для исправной работы сервиса.");
            messageBuilder.AppendLine($"Маркетплейс: {MarketplaceNameConverter.Convert(connection.MarketplaceName)}.");

            if (exeption.Service.HasValue)
            {
                messageBuilder.AppendLine($"Сервис: {ProjectServiceNameConverter.Convert(exeption.Service.Value)}");
            }

            await _userNotificationsService.AddAsync(messageBuilder.ToString());
        }

        private void UseAttemptCounter(MarketplaceConnectionEntity connection)
        {
            if (connection.LastBadConnectDate.Date != DateTime.UtcNow.Date)
            {
                connection.NumConnectionsAttempt = 0;
                connection.LastBadConnectDate = DateTime.UtcNow;
            }

            connection.NumConnectionsAttempt += 1;
        }

        private void UseActivateStatusHandler(AppConnectionBadRequestException exeption)
        {
            if(exeption.MarketplaceConnection.NumConnectionsAttempt > _maxNumErrors
                || exeption.HttpStatusCode == HttpStatusCode.Unauthorized
                || exeption.HttpStatusCode == HttpStatusCode.Forbidden)
            {
                exeption.MarketplaceConnection.IsActive = false;
            }
        }
    }
}
