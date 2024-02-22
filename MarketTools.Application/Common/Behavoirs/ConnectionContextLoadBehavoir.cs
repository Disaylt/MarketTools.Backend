using MarketTools.Domain.Interfaces.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Common.Behavoirs
{
    public class ConnectionContextLoadBehavoir<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IConnectionContextCall
    {
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Console.WriteLine("asdasda");
            Console.WriteLine("asdasda");
            Console.WriteLine("asdasda");
            Console.WriteLine("asdasda");
            Console.WriteLine("asdasda");
            Console.WriteLine("asdasda");
            return next();
        }
    }
}
