using MarketTools.WebApi.Middlewares;

namespace MarketTools.WebApi.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseWriteAuthHelper(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<UserIdMiddleware>();

            return builder;
        }

        public static IApplicationBuilder UseWebExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<WebExeptionHandlerMiddleware>();

            return builder;
        }
    }
}
