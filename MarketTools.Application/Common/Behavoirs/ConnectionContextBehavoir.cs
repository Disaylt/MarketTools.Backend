using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
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
    public class ConnectionContextBehavoir<TRequest, TResponse>(IMarketplaceConnectionService _marketplaceConnectionService,
        IContextService<MarketplaceConnectionEntity> _contextService)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IConnectionContextCall
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_contextService.IsExists() is false)
            {
                _contextService.Context = await _marketplaceConnectionService.GetWithDetailsAsync(request.ConnectionId);
            }

            return await next();
        }
    }
}
