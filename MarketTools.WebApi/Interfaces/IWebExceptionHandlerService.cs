namespace MarketTools.WebApi.Interfaces
{
    public interface IWebExceptionHandlerService<T> where T : Exception
    {
        public Task HandleAsync(HttpContext context, T exception);
    }
}
