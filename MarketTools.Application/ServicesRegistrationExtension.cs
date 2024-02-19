using FluentValidation;
using MarketTools.Application.Common.Behavoirs;
using MarketTools.Domain.Common.Configuration;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace MarketTools.Application
{
    public static class ServicesRegistrationExtension
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddMedatorRequests(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }

        public static HostApplicationBuilder AddConfiguration(this HostApplicationBuilder builder)
        {
            builder.Configuration
                .AddJsonFile(
                $"{builder.Configuration.GetValue<string>("MpToolsSettingsPath")}sequreconfig.{builder.Environment.EnvironmentName}.json",
                false);
            builder.Services.Configure<SequreSettings>(builder.Configuration.GetSection("Sequre"));

            return builder;
        }
    }
}
