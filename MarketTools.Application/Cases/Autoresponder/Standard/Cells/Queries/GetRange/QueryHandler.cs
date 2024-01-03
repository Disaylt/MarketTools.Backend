﻿using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Cells.Models;
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
        (IAuthUnitOfWork _authUnitOfWork,
        IMapper _mapper)
        : IRequestHandler<GetRangeQuery, IEnumerable<CellVm>>
    {
        private readonly IRepository<StandardAutoresponderCell> _repository = _authUnitOfWork.StandardAutoresponderCells;
        public async Task<IEnumerable<CellVm>> Handle(GetRangeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<StandardAutoresponderCell> entities = await _repository.GetRangeAsync(x => x.ColumnId == request.CollumnId);

            return _mapper.Map<IEnumerable<CellVm>>(entities);
        }
    }
}
