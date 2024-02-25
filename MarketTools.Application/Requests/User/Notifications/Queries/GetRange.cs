using AutoMapper;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Requests;
using MarketTools.Application.Requests.User.Notifications.Models;
using MarketTools.Application.Requests.User.Notifications.Utilities;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.Connections;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.User.Notifications.Queries
{
    public class GetRangeNotificationsQuery : GetRangeQuery<UserNotificationVm>
    {
        public bool? IsRead { get; set; }
        public bool IsSetReadStatus { get; set; }
    }

    public class GetRangeQueryHandler(IAuthUnitOfWork _authUnitOfWork, IMapper _mapper)
       : IRequestHandler<GetRangeNotificationsQuery, IEnumerable<UserNotificationVm>>
    {
        private readonly IRepository<UserNotificationEntity> _repository = _authUnitOfWork.GetRepository<UserNotificationEntity>();
        public async Task<IEnumerable<UserNotificationVm>> Handle(GetRangeNotificationsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<UserNotificationEntity> entities = await GetRangeNotificationsAsync(request);

            IEnumerable<UserNotificationVm> viewNotifications = _mapper.Map<IEnumerable<UserNotificationVm>>(entities);

            if (request.IsSetReadStatus)
            {
                SetReadStatus(entities);
            }

            await _authUnitOfWork.CommitAsync(cancellationToken);

            return viewNotifications;
        }

        private void SetReadStatus(IEnumerable<UserNotificationEntity> entities)
        {
            List<UserNotificationEntity> entitiesForUpdate = new List<UserNotificationEntity>();

            foreach (UserNotificationEntity entity in entities)
            {
                if (entity.IsRead == false)
                {
                    entity.IsRead = true;
                    entitiesForUpdate.Add(entity);
                }
            }

            if (entitiesForUpdate.Count > 0)
            {
                _repository.UpdateRange(entitiesForUpdate);
            }
        }

        private async Task<IEnumerable<UserNotificationEntity>> GetRangeNotificationsAsync(GetRangeNotificationsQuery request)
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
