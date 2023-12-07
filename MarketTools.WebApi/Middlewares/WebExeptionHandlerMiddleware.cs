using FluentValidation;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.WebApi.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using System;
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
                    case ValidationException exception:
                        await RunExceptionHandlerAsync(context, serviceProvider, exception);
                        break;
                    case DefaultBadRequestException exception:
                        await RunExceptionHandlerAsync(context, serviceProvider, exception);
                        break;
                    case DefaultNotFoundException exception:
                        await RunExceptionHandlerAsync(context, serviceProvider, exception);
                        break;
                    case IdentityUnauthorizedException exception:
                        await RunExceptionHandlerAsync(context, serviceProvider, exception);
                        break;
                    default:
                        throw;
                }
            }
        }

        private async Task RunExceptionHandlerAsync<T>(HttpContext context, IServiceProvider serviceProvider, T exception) where T : Exception
        {
            IWebExceptionHandlerService<T> exceptionHandlerService = serviceProvider.GetRequiredService<IWebExceptionHandlerService<T>>();
            await exceptionHandlerService.HandleAsync(context, exception);
        }
    }
}
