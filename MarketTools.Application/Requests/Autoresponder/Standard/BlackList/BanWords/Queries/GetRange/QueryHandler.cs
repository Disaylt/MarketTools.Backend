using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.BanWords.Queries.GetRange
{
    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<BanWordGetRangeQuery, IEnumerable<StandardAutoresponderBanWordEntity>>
    {
        private readonly IRepository<StandardAutoresponderBanWordEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderBanWordEntity>();

        public async Task<IEnumerable<StandardAutoresponderBanWordEntity>> Handle(BanWordGetRangeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync(x => x.BlackListId == request.BlackListId);
        }
    }
}
