using AutoMapper;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Cells.Queries.GetRange
{
    public class QueryHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<CellGetRangeQuery, IEnumerable<StandardAutoresponderCellEntity>>
    {
        private readonly IRepository<StandardAutoresponderCellEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderCellEntity>();
        public async Task<IEnumerable<StandardAutoresponderCellEntity>> Handle(CellGetRangeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync(x => x.ColumnId == request.CollumnId);
        }
    }
}
