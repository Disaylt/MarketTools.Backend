using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Application.Models.Identity;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Services.Notifications
{
    internal class UserNotificationsService(IContextService<IdentityContext> _identityContext, IUnitOfWork _unitOfWork)
        : IUserNotificationsService
    {

        private readonly IRepository<UserNotificationEntity> _repository = _unitOfWork.GetRepository<UserNotificationEntity>();

        public async Task<UserNotificationEntity> AddWithoutCommitAsync(string text)
        {
            UserNotificationEntity entity = new UserNotificationEntity
            {
                Text = text,
                UserId = _identityContext.Context.UserId
            };
            await _repository.AddAsync(entity);

            return entity;
        }
    }
}
