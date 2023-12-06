using MarketTools.Application.Interfaces.Identity;
using System.Security.Claims;

namespace MarketTools.WebApi.Middlewares
{
    public class WebExeptionHandlerMiddleware(RequestDelegate _next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
