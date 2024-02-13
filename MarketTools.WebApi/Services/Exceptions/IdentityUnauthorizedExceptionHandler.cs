using MarketTools.Application.Common.Exceptions;
using MarketTools.WebApi.Interfaces;
using MarketTools.WebApi.Models.Exceptions;
using System.Net;

namespace MarketTools.WebApi.Services.Exceptions
{
    public class IdentityUnauthorizedExceptionHandler : IWebExceptionHandlerService<IdentityUnauthorizedException>
    {
        public async Task HandleAsync(HttpContext context, IdentityUnauthorizedException exception)
        {
            IEnumerable<string> errorMessagess = new List<string>() { exception.Message };

            ErrorResultVm problemDetails = new ErrorResultVm
            {
                Type = "Unauthorized",
                Title = "User id is null",
                Status = (int)HttpStatusCode.Unauthorized,
                Errors = new Dictionary<string, IEnumerable<string>>()
                {
                    {"Details",  errorMessagess }
                }
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
