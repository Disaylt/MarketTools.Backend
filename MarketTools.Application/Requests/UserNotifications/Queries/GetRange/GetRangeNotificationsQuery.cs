using MarketTools.Application.Models.Requests;
using MarketTools.Application.Requests.MarketplaceConnections.Queries.GetRangePagination;
using MarketTools.Application.Requests.User.Notifications.Models;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.UserNotifications.Queries.GetRange
{
    public class GetRangeNotificationsQuery : GetRangeQuery<UserNotificationVm>
    {
        public bool? IsRead { get; set; }
        public bool IsSetReadStatus { get; set; }
    }
}
