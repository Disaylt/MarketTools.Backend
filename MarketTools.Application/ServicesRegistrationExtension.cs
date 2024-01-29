using FluentValidation;
using MarketTools.Application.Common.Behavoirs;
using MarketTools.Application.Common.Mappings;
using MarketTools.Application.Interfaces;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Services;
using MarketTools.Application.Services.Autroesponder.Standard;
using MarketTools.Domain.Common.Configuration;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application
{
    public static class ServicesRegistrationExtension
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddSingleton<IModelStateValidationService, ModelStateValidationService>();

            services.AddScoped<AutoresponderContextService>();
            services.AddScoped<IAutoresponderContextWriter>(x=> x.GetRequiredService<AutoresponderContextService>());
            services.AddScoped<IAutoresponderContextReader>(x => x.GetRequiredService<AutoresponderContextService>());

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
