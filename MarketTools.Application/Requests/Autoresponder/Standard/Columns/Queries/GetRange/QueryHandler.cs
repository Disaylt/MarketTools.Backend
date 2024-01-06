using AutoMapper;
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
        : IRequestHandler<GetRangeQuery, IEnumerable<StandardAutoresponderColumnEntity>>
    {
        private readonly IRepository<StandardAutoresponderColumnEntity> _repository = _authUnitOfWork.StandardAutoresponderColumns;
        public async Task<IEnumerable<StandardAutoresponderColumnEntity>> Handle(GetRangeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync(x=> x.Type == request.Type);
        }
    }
}
