using AutoMapper;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Queries.GetRange
{
    public class QueryHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GetRangeQuery, IEnumerable<StandardAutoresponderTemplateEntity>>
    {
        private readonly IRepository<StandardAutoresponderTemplateEntity> _repository = _authUnitOfWork.StandardAutoresponderTemplates;
        public async Task<IEnumerable<StandardAutoresponderTemplateEntity>> Handle(GetRangeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync();
        }
    }
}
