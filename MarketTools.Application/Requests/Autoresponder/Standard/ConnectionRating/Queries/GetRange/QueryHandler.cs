using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Requests;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Queries.GetRange
{
    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GetRangeRatingsQuery, IEnumerable<StandardAutoresponderConnectionRatingEntity>>
    {

        private readonly IRepository<StandardAutoresponderConnectionRatingEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderConnectionRatingEntity>();

        public async Task<IEnumerable<StandardAutoresponderConnectionRatingEntity>> Handle(GetRangeRatingsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsQueryable()
                .Where(x => x.ConnectionId == request.ConnectionId)
                .Include(x => x.Templates)
                .ToListAsync();
        }
    }
}
