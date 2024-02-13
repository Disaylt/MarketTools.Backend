using FluentValidation;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.WebApi.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
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
            catch(ValidationException exception)
            {
                await RunExceptionHandlerAsync(context, serviceProvider, exception);
            }
            catch(AppBadRequestException exception)
            {
                await RunExceptionHandlerAsync<Exception>(context, serviceProvider, exception);
            }
            catch(AppNotFoundException exception)
            {
                await RunExceptionHandlerAsync(context, serviceProvider, exception);
            }
            catch(IdentityUnauthorizedException exception)
            {
                await RunExceptionHandlerAsync(context, serviceProvider, exception);
            }
            catch(DbUpdateException exception)
            {
                await RunExceptionHandlerAsync(context, serviceProvider, exception);
            }
            catch(AppConnectionBadRequestException exception)
            {
                await RunExceptionHandlerAsync<Exception>(context, serviceProvider, exception);
            }
        }

        private async Task RunExceptionHandlerAsync<T>(HttpContext context, IServiceProvider serviceProvider, T exception) where T : Exception
        {
            IWebExceptionHandlerService<T> exceptionHandlerService = serviceProvider.GetRequiredService<IWebExceptionHandlerService<T>>();
            await exceptionHandlerService.HandleAsync(context, exception);
        }
    }
}
