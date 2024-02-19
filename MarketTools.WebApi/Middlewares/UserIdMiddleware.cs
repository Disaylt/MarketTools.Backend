using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Models.Identity;
using MarketTools.Infrastructure.Identity;
using System.Security.Claims;

namespace MarketTools.WebApi.Middlewares
{
    public class UserIdMiddleware(RequestDelegate _next)
    {

        public async Task Invoke(HttpContext context, IContextService<IdentityContext> _identityContext)
        {
            string? userId = context.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                _identityContext.Context = new IdentityContext { UserId = userId };
            }

            await _next(context);
        }
    }
}
