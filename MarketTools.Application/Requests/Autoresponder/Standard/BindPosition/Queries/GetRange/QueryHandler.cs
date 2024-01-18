using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.ColumnBindPosition.Queries.GetRange
{
    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<BindPositionGetRangeQuery, IEnumerable<StandardAutoresponderBindPositionEntity>>
    {
        private readonly IRepository<StandardAutoresponderBindPositionEntity> _repository = _authUnitOfWork.StandardAutoresponderBindPositions;

        public async Task<IEnumerable<StandardAutoresponderBindPositionEntity>> Handle(BindPositionGetRangeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync(x => 
                x.TemplateId == request.TemplateId && x.Column.Type == request.ColumnType, 
                cancellationToken);
        }
    }
}
