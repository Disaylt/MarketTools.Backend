using MarketTools.Application.Common.Exceptions;
using MarketTools.WebApi.Interfaces;
using MarketTools.WebApi.Models.Exceptions;
using System.Net;

namespace MarketTools.WebApi.Services.Exceptions
{
    public class DefaultBadRequestExceptionHandlerService : IWebExceptionHandlerService<DefaultBadRequestException>
    {
        public async Task HandleAsync(HttpContext context, DefaultBadRequestException exception)
        {
            IEnumerable<string> errorMessagess = new List<string>() { exception.Message };

            ErrorResultVm problemDetails = new ErrorResultVm
            {
                Type = "Bad request",
                Title = "Default bad request",
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
