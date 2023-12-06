using MarketTools.Application.Interfaces.Identity;
using MarketTools.Infrastructure.Identity;
using System.Security.Claims;

namespace MarketTools.WebApi.Middlewares
{
    public class UserIdMiddleware(RequestDelegate _next)
    {

        public async Task Invoke(HttpContext context, IAuthWriteHelper authWriteHelper)
        {
            string? userId = context.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                authWriteHelper.Set(userId);
            }

            await _next(context);
        }
    }
}
