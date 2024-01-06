﻿using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Columns.Models;
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
        (IMapper _mapper,
        IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GetRangeQuery, IEnumerable<ColumnVm>>
    {
        private readonly IRepository<StandardAutoresponderColumn> _repository = _authUnitOfWork.StandardAutoresponderColumns;
        public async Task<IEnumerable<ColumnVm>> Handle(GetRangeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<StandardAutoresponderColumn> entities = await _repository.GetRangeAsync(x=> x.Type == request.Type);

            IEnumerable<ColumnVm> result = _mapper.Map<IEnumerable<ColumnVm>>(entities);

            return result;
        }
    }
}