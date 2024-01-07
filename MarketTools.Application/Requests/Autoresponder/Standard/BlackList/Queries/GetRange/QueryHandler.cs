using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.Queries.GetRange
{
    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GetRangeQuery, IEnumerable<StandardAutoresponderBlackListEntity>>
    {
        private readonly IRepository<StandardAutoresponderBlackListEntity> _repository = _authUnitOfWork.StandardAutoresponderBlackLists;
        public async Task<IEnumerable<StandardAutoresponderBlackListEntity>> Handle(GetRangeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync(cancellationToken);
        }
    }
}
