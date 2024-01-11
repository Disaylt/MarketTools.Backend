using MarketTools.WebApi.Interfaces;
using MarketTools.WebApi.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Net;

namespace MarketTools.WebApi.Services.Exceptions
{
    public class EntityFrameworkExceptionHandlerService : IWebExceptionHandlerService<DbUpdateException>
    {
        public async Task HandleAsync(HttpContext context, DbUpdateException exception)
        {
            IEnumerable<string> errorMessagess = new List<string>() 
            {
                "Объект не удовлетворяет условиям обновления."
            };

            ErrorResultVm problemDetails = new ErrorResultVm
            {
                Type = "Bad request",
                Title = "Database bad request",
                Status = (int)HttpStatusCode.BadRequest,
                Errors = new Dictionary<string, IEnumerable<string>>()
                {
                    {"Details",  errorMessagess }
                }
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
