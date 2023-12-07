using MarketTools.Application.Common.Exceptions;
using MarketTools.WebApi.Interfaces;
using MarketTools.WebApi.Models.Exceptions;
using System.Net;

namespace MarketTools.WebApi.Common.Exceptions
{
    public class DefaultNotFoundExceptionHandlerService : IWebExceptionHandlerService<DefaultNotFoundException>
    {
        public async Task HandleAsync(HttpContext context, DefaultNotFoundException exception)
        {
            IEnumerable<string> errorMessagess = new List<string>() { exception.Message };

            ErrorResultVm problemDetails = new ErrorResultVm
            {
                Type = "Not found",
                Title = "Default not found exception",
                Status = (int)HttpStatusCode.NotFound,
                Errors = new Dictionary<string, IEnumerable<string>>()
                {
                    {"Details",  errorMessagess }
                }
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
