using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Reports.Queries.GetRange
{
    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GetRangeReportsQuery, IEnumerable<StandardAutoresponderNotificationEntity>>
    {

        private readonly IRepository<StandardAutoresponderNotificationEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderNotificationEntity>();

        public Task<IEnumerable<StandardAutoresponderNotificationEntity>> Handle(GetRangeReportsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
