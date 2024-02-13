using FluentValidation;
using MarketTools.WebApi.Interfaces;
using MarketTools.WebApi.Models.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace MarketTools.WebApi.Services.Exceptions
{
    public class ValidationExceptionHandlerService : IWebExceptionHandlerService<ValidationException>
    {
        public async Task HandleAsync(HttpContext context, ValidationException exception)
        {
            ErrorResultVm problemDetails = new ErrorResultVm
            {
                Type = "MediatR validation exception",
                Title = exception.Message,
                Status = (int)HttpStatusCode.BadRequest,
                Errors = new Dictionary<string, IEnumerable<string>>()
                {
                    {"ValidationErrors",  new List<string> { exception.Message } }
                }
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
