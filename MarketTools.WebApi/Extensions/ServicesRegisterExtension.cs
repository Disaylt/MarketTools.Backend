
using MarketTools.Application.Common.Mappings;
using System.Reflection;

namespace MarketTools.WebApi.Extensions
{
    public static class ServicesRegisterExtension
    {
        public static IServiceCollection AddCurrentApp(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            });

            return serviceDescriptors;
        }
    }
}
