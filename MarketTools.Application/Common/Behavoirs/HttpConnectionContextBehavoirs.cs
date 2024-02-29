using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Http;
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
    public class HttpConnectionContextBehavoirs<TRequest, TResponse>(IMarketplaceConnectionService _marketplaceConnectionService,
        IHttpConnectionContextService _httpConnectionContextService)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IHttpConnectionContextCall
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_httpConnectionContextService.IsContains(request.ConnectionId) is false)
            {
                MarketplaceConnectionEntity entity = await _marketplaceConnectionService.GetWithDetailsAsync(request.ConnectionId);
                _httpConnectionContextService.Set(entity);
            }

            return await next();
        }
    }
}
