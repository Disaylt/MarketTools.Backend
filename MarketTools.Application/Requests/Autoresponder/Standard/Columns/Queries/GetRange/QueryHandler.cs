﻿using AutoMapper;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Columns.Queries.GetRange
{
    public class QueryHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<ColumnGetRangeQuery, IEnumerable<StandardAutoresponderColumnEntity>>
    {
        private readonly IRepository<StandardAutoresponderColumnEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderColumnEntity>();
        public async Task<IEnumerable<StandardAutoresponderColumnEntity>> Handle(ColumnGetRangeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync(x=> x.Type == request.Type);
        }
    }
}
