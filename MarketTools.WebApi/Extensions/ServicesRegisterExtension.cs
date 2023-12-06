
using FluentValidation;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Common.Mappings;
using MarketTools.WebApi.Common.Exceptions;
using MarketTools.WebApi.Interfaces;
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
            serviceDescriptors.AddScoped<IWebExceptionHandlerService<ValidationException>, ValidationExceptionHandlerService>();
            serviceDescriptors.AddScoped<IWebExceptionHandlerService<DefaultBadRequestException>, DefaultBadRequestExceptionHandlerService>();

            return serviceDescriptors;
        }
    }
}
