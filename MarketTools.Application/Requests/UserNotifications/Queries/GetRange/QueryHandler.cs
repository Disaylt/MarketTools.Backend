using AutoMapper;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Requests.UserNotifications.Models;
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
    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork, IMapper _mapper)
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

            await _authUnitOfWork.CommintAsync(cancellationToken);

            return viewNotifications;
        }

        private void SetReadStatus(IEnumerable<UserNotificationEntity> entities)
        {
            List<UserNotificationEntity> entitiesForUpdate = new List<UserNotificationEntity>();

            foreach (UserNotificationEntity entity in entities)
            {
                if(entity.IsRead == false)
                {
                    entity.IsRead = true;
                    entitiesForUpdate.Add(entity);
                }
            }

            if(entitiesForUpdate.Count > 0)
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
