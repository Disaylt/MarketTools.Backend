using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Requests.User.Notifications.Utilities;
using MarketTools.Application.Requests.UserNotifications.Queries;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.User.Notifications.Queries
{
    public class CountNotificationsQuery : IRequest<int>
    {
        public bool? IsRead { get; set; }
    }

    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<CountNotificationsQuery, int>
    {

        private readonly IRepository<UserNotificationEntity> _repository = _authUnitOfWork.GetRepository<UserNotificationEntity>();

        public async Task<int> Handle(CountNotificationsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<UserNotificationEntity> query = _repository.GetAsQueryable();

            return await new UserNotificationQueryBuilder(query)
                .SetReadStatus(request.IsRead)
                .Build()
                .CountAsync();
        }
    }
}
