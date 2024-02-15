using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.Queries
{
    public class BlackListGetRangeQuery
        : IRequest<IEnumerable<StandardAutoresponderBlackListEntity>>
    {

    }

    public class GetRangeQueryHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<BlackListGetRangeQuery, IEnumerable<StandardAutoresponderBlackListEntity>>
    {
        private readonly IRepository<StandardAutoresponderBlackListEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderBlackListEntity>();
        public async Task<IEnumerable<StandardAutoresponderBlackListEntity>> Handle(BlackListGetRangeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync(cancellationToken);
        }
    }
}
