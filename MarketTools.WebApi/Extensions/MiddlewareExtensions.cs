using MarketTools.WebApi.Middlewares;

namespace MarketTools.WebApi.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder SetUserIdToAuthHelper(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserIdMiddleware>();
        }
    }
}
