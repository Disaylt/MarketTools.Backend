using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Interfaces.Requests;
using MediatR;

namespace MarketTools.Application.Common.Behavoirs
{
    public class StandardAutoresponderContextBehavoir<TRequest, TResponse>(IContextService<AutoresponderContext> _autoresponderContext,
        IAutoresponderContextLoadService _autoresponderContextService)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IStandardAutoresponderContextCall
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_autoresponderContext.IsExists() == false)
            {
                _autoresponderContext.Context = await _autoresponderContextService.Create(request.ConnectionId);
            }

            return await next();
        }
    }
}
