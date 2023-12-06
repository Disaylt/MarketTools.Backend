using MarketTools.Application.Interfaces.Identity;
using System.Security.Claims;

namespace MarketTools.WebApi.Middlewares
{
    public class UserIdMiddleware(RequestDelegate _next, IAuthWriteHelper _authWriteHelper)
    {
        public async Task Invoke(HttpContext context)
        {
            string? userId = context.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                _authWriteHelper.Set(userId);
            }

            await _next(context);
        }
    }
}
