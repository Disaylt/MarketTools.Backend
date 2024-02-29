using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Common.Behavoirs
{
    public class ConnectionContextBehavoir<TRequest, TResponse>(IContextService<MarketplaceConnectionEntity> _contextService,
        IAuthUnitOfWork _authUnitOfWork)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IConnectionContextCall
    {
        private readonly IRepository<MarketplaceConnectionEntity> _repository = _authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_contextService.IsExists() is false)
            {
                _contextService.Context = await _repository.FirstAsync(x => x.Id == request.ConnectionId);
            }

            return await next();
        }
    }
}
