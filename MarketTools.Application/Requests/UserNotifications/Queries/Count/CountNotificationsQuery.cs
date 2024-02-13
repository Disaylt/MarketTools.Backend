using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.UserNotifications.Queries.Count
{
    public class CountNotificationsQuery : IRequest<int>
    {
        public bool? IsRead { get; set; }
    }
}
