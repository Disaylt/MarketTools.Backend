using FluentValidation;
using FluentValidation.Results;
using MarketTools.Application.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Common.Behavoirs
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> _validators)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(async v => await v.ValidateAsync(context))
                .SelectMany(result => result.Result.Errors)
                .FirstOrDefault(x => x != null);

            if(failures != null)
            {
                ThrowErrorByCode(failures);
            }

            return next();
        }

        private void ThrowErrorByCode(ValidationFailure validationFailure)
        {
            switch (validationFailure.ErrorCode)
            {
                case "404":
                    throw new AppNotFoundException(validationFailure.ErrorMessage);
                default:
                    throw new ValidationException(validationFailure.ErrorMessage);
            }
        }
    }
}
