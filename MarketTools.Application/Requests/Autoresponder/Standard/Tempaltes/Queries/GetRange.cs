using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Queries
{
    public class TemplateGetRangeQuery : IRequest<IEnumerable<StandardAutoresponderTemplateEntity>>
    {

    }

    public class GetRangeQueryHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<TemplateGetRangeQuery, IEnumerable<StandardAutoresponderTemplateEntity>>
    {
        private readonly IRepository<StandardAutoresponderTemplateEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderTemplateEntity>();
        public async Task<IEnumerable<StandardAutoresponderTemplateEntity>> Handle(TemplateGetRangeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync();
        }
    }
}
