using FluentValidation;
using MarketTools.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MarketTools.WebApi.Services.Exceptions
{
    public class ValidationExceptionHandlerService : IWebExceptionHandlerService<ValidationException>
    {
        public async Task HandleAsync(HttpContext context, ValidationException exception)
        {
            IEnumerable<string> errorMessagess = exception.Errors
                .Select(x=> x.ErrorMessage)
                .ToList();

            ProblemDetails problemDetails = new ProblemDetails
            {
                Type = "MediatR validation exception",
                Title = exception.Message,
                Status = (int)HttpStatusCode.BadRequest,
                Extensions = new Dictionary<string, object?>()
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
