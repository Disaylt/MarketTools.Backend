using FluentValidation;
using MarketTools.WebApi.Interfaces;
using MarketTools.WebApi.Models.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace MarketTools.WebApi.Common.Exceptions
{
    public class ValidationExceptionHandlerService : IWebExceptionHandlerService<ValidationException>
    {
        public async Task HandleAsync(HttpContext context, ValidationException exception)
        {
            IEnumerable<string> errorMessagess = exception.Errors
                .Select(x => x.ErrorMessage)
                .ToList();

            ErrorResultVm problemDetails = new ErrorResultVm
            {
                Type = "MediatR validation exception",
                Title = exception.Message,
                Status = (int)HttpStatusCode.BadRequest,
                Errors = new Dictionary<string, IEnumerable<string>>()
                {
                    {"ValidationErrors",  errorMessagess }
                }
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
