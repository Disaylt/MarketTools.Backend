using MarketTools.Application.Models.Common;

namespace MarketTools.WebApi.Extensions
{
    public static class ServicesRegisterExtension
    {
        public static IServiceCollection AddCurrentApp(this IServiceCollection serviceDescriptors)
        {

            return serviceDescriptors;
        }
    }
}
