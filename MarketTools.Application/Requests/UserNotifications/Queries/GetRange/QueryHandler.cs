using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.UserNotifications.Queries.GetRange
{
    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GetRangeNotificationsQuery, IEnumerable<UserNotificationEntity>>
    {
        private readonly IRepository<UserNotificationEntity> _repository = _authUnitOfWork.GetRepository<UserNotificationEntity>();
        public async Task<IEnumerable<UserNotificationEntity>> Handle(GetRangeNotificationsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<UserNotificationEntity> query = _repository.GetAsQueryable();

            return await new UserNotificationQueryBuilder(query)
                .SetReadStatus(request.IsRead)
                .SetPagination(request.PageRequest)
                .Build()
                .ToListAsync();
        }
    }
}
