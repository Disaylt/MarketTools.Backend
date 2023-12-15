using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Cells.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Cells.Queries.GetList
{
    public class QueryHandler
        (IAuthUnitOfWork _authUnitOfWork,
        IMapper _mapper)
        : IRequestHandler<GetRangeQuery, IEnumerable<CellVm>>
    {
        private readonly IAuthRepository<AutoresponderCell> _repository = _authUnitOfWork.AutoresponderCells;
        public async Task<IEnumerable<CellVm>> Handle(GetRangeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AutoresponderCell> entities = await _repository.GetRangeAsync(x => x.ColumnId == request.CollumnId);

            return _mapper.Map<IEnumerable<CellVm>>(entities);
        }
    }
}
