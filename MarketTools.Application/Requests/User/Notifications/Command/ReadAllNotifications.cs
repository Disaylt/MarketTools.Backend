using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.User.Notifications.Command
{
    public class ReadAllNotificationCommand : IRequest<Unit>
    {

    }

    public class ReadAllNotificationsHandler(IAuthUnitOfWork _authUnitOfWork)
        :IRequestHandler<ReadAllNotificationCommand, Unit>
    {

        private readonly IRepository<UserNotificationEntity> _repository = _authUnitOfWork.GetRepository<UserNotificationEntity>();

        public async Task<Unit> Handle(ReadAllNotificationCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<UserNotificationEntity> notifications = await _repository.GetRangeAsync(x => x.IsRead == false);

            foreach (var notification in notifications)
            {
                notification.IsRead = true;
            }

            _repository.UpdateRange(notifications);
            await _authUnitOfWork.CommintAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
