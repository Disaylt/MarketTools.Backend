using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Requests;
using MarketTools.Application.Requests.Autoresponder.Standard.Reports.Utilities;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Reports.Queries
{
    public class GetRangeReportsQuery : GetRangeQuery<StandardAutoresponderNotificationEntity>
    {
        public int? ConnectionId { get; set; }
        public int? Rating { get; set; }
        public bool? IsSuccess { get; set; }
        public string? Article { get; set; }
    }

    public class GetRangeQueryHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GetRangeReportsQuery, IEnumerable<StandardAutoresponderNotificationEntity>>
    {

        private readonly IRepository<StandardAutoresponderNotificationEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderNotificationEntity>();

        public async Task<IEnumerable<StandardAutoresponderNotificationEntity>> Handle(GetRangeReportsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<StandardAutoresponderNotificationEntity> query = _repository
                .GetAsQueryable();

            return await new ReportsQueryBuilder(query)
                .SetConnectionId(request.ConnectionId)
                .SetArticle(request.Article)
                .SetRating(request.Rating)
                .SetSuccesStatus(request.IsSuccess)
                .SetPagination(request.PageRequest)
                .Build()
                .ToListAsync();
        }
    }
}
