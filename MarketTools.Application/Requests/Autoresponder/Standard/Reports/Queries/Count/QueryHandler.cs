using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Reports.Queries.Count
{
    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<CountReportsQuery, int>
    {
        private readonly IRepository<StandardAutoresponderNotificationEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderNotificationEntity>();
        public async Task<int> Handle(CountReportsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<StandardAutoresponderNotificationEntity> query = _repository
                .GetAsQueryable();

            return await new ReportsQueryBuilder(query)
                .SetConnectionId(request.ConnectionId)
                .SetArticle(request.Article)
                .SetRating(request.Rating)
                .SetSuccesStatus(request.IsSuccess)
                .Build()
                .CountAsync();
        }
    }
}
