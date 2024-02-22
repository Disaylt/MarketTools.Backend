using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Interfaces.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MarketTools.Application.Common.Behavoirs
{
    public class StandardAutoresponderContextBehavoir<TRequest, TResponse>(IContextService<AutoresponderContext> _autoresponderContext,
        IAutoresponderContextLoadService _autoresponderContextService)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IStandardAutoresponderContextCall
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _autoresponderContext.Context = await _autoresponderContextService.Create(request.ConnectionId);

            return await next();
        }
    }
}
