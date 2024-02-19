using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Columns.Queries
{
    public class ColumnGetRangeQuery : IRequest<IEnumerable<StandardAutoresponderColumnEntity>>
    {
        public AutoresponderColumnType Type { get; set; }
    }

    public class GetRangeQueryHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<ColumnGetRangeQuery, IEnumerable<StandardAutoresponderColumnEntity>>
    {
        private readonly IRepository<StandardAutoresponderColumnEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderColumnEntity>();
        public async Task<IEnumerable<StandardAutoresponderColumnEntity>> Handle(ColumnGetRangeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync(x => x.Type == request.Type);
        }
    }
}
