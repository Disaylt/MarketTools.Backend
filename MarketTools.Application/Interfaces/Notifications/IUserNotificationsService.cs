﻿using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Notifications
{
    public interface IUserNotificationsService
    {
        public Task<UserNotificationEntity> AddWithoutCommitAsync(string text);
    }
}
