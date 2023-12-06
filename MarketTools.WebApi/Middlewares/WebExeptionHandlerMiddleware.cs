using FluentValidation;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.WebApi.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using System.Security.Claims;

namespace MarketTools.WebApi.Middlewares
{
    public class WebExeptionHandlerMiddleware(RequestDelegate _next)
    {
        public async Task Invoke(HttpContext context, IServiceProvider serviceProvider)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                switch (ex)
                {
                    case ValidationException validationException:
                        await RunValidationExceptionHandlerAsync(context, serviceProvider, validationException);
                        break;
                    default:
                        throw;
                }
            }
        }

        private async Task RunValidationExceptionHandlerAsync(HttpContext context, IServiceProvider serviceProvider, ValidationException validationException)
        {
            IWebExceptionHandlerService<ValidationException> exceptionHandlerService = serviceProvider.GetRequiredService<IWebExceptionHandlerService<ValidationException>>();
            await exceptionHandlerService.HandleAsync(context, validationException);
        }
    }
}
