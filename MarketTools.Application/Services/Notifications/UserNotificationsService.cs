using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Services.Notifications
{
    internal class UserNotificationsService(IAuthReadHelper _authReadHelper, IUnitOfWork _unitOfWork)
        : IUserNotificationsService
    {

        private readonly IRepository<UserNotificationEntity> _repository = _unitOfWork.GetRepository<UserNotificationEntity>();

        public async Task<UserNotificationEntity> AddWithoutCommitAsync(string text)
        {
            UserNotificationEntity entity = new UserNotificationEntity
            {
                Text = text,
                UserId = _authReadHelper.UserId
            };
            await _repository.AddAsync(entity);

            return entity;
        }
    }
}
