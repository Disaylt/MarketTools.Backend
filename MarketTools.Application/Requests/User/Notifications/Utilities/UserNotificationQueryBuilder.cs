using MarketTools.Application.Common.Builders;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.User.Notifications.Utilities
{
    internal class UserNotificationQueryBuilder : BaseQueryBuilder<UserNotificationEntity>
    {
        public UserNotificationQueryBuilder(IQueryable<UserNotificationEntity> query) : base(query)
        {

        }

        public UserNotificationQueryBuilder SetReadStatus(bool? isRead)
        {
            if (isRead.HasValue)
            {
                Query = Query.Where(x => x.IsRead == isRead.Value);
            }

            return this;
        }
    }
}
