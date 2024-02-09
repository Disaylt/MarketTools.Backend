using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<StandardAutoresponderNotificationEntity>> Handle(GetRangeReportsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<StandardAutoresponderNotificationEntity> query = _repository.GetAsQueryable();

            return await new ReportsQueryBuilder(query)
                .SetConnectionId(request.ConnectionId)
                .SetPagination(request.PageRequest)
                .Build()
                .ToListAsync();
        }
    }
}
