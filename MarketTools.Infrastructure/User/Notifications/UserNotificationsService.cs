using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Application.Models.Identity;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.User.Notifications
{
    internal class UserNotificationsService(IContextService<IdentityContext> _identityContext, IUnitOfWork _unitOfWork)
        : IUserNotificationsService
    {

        private readonly IRepository<UserNotificationEntity> _repository = _unitOfWork.GetRepository<UserNotificationEntity>();

        public async Task<UserNotificationEntity> AddAsync(string text, bool isUseCommit = false)
        {
            UserNotificationEntity entity = new UserNotificationEntity
            {
                Text = text,
                UserId = _identityContext.Context.UserId
            };
            await _repository.AddAsync(entity);
            await _unitOfWork.UseCommit(isUseCommit);

            return entity;
        }
    }
}
