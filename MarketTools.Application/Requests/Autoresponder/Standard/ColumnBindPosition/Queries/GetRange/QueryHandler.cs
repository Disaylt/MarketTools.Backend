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
        : IRequestHandler<ColumnsBindPositionGetQuery, IEnumerable<StandardAutoresponderColumnBindPositionEntity>>
    {
        private readonly IRepository<StandardAutoresponderColumnBindPositionEntity> _repository = _authUnitOfWork.StandardAutoresponderColumnBindPositions;

        public async Task<IEnumerable<StandardAutoresponderColumnBindPositionEntity>> Handle(ColumnsBindPositionGetQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync(x => 
                x.TemplateId == request.TemplateId && x.Column.Type == request.ColumnType, 
                cancellationToken);
        }
    }
}
