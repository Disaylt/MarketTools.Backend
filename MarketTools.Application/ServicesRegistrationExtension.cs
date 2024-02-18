﻿using FluentValidation;
using MarketTools.Application.Common.Behavoirs;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Common.Mappings;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Application.Services.Autroesponder.Standard;
using MarketTools.Application.Utilities;
using MarketTools.Application.Utilities.Autoresponder.Standard;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Application.Utilities.ProjectServices;
using MarketTools.Domain.Common.Configuration;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
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
            AddConnectionDeterminant(services);
            AddServiceValidators(services);

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

        private static void AddServiceValidators(IServiceCollection services)
        {
            services.AddScoped<IProjectServiceFactory<IServiceValidator>>(serviceProvider => new ConnectionServiceFactory<IServiceValidator>(
                new Dictionary<MarketplaceName, Func<IServiceProvider, IMarketplaceProvider<IServiceValidator>>> {
                    { MarketplaceName.WB, x=> x.GetRequiredService<WbProjectServiceProvider<IServiceValidator>>() }
                }, serviceProvider));

            services.AddScoped(serviceProvider => new WbProjectServiceProvider<IServiceValidator>(
                new Dictionary<EnumProjectServices, Func<IServiceProvider, IServiceValidator>>
                {
                    { EnumProjectServices.StandardAutoresponder, x=> x.GetRequiredService<WbStandardAutoresponderValidator>() }
                }, serviceProvider));

            services.AddScoped<WbStandardAutoresponderValidator>();
        }

        private static void AddConnectionDeterminant(IServiceCollection services)
        {
            services.AddScoped<IProjectServiceFactory<IConnectionSerivceDeterminant>>(serviceProvider => new ConnectionServiceFactory<IConnectionSerivceDeterminant>(
                new Dictionary<MarketplaceName, Func<IServiceProvider, IMarketplaceProvider<IConnectionSerivceDeterminant>>>
                {
                    {MarketplaceName.WB, x=> x.GetRequiredService<WbProjectServiceProvider<IConnectionSerivceDeterminant>>() }
                },serviceProvider));

            services.AddScoped(serviceProvider => new WbProjectServiceProvider<IConnectionSerivceDeterminant>(
                new Dictionary<EnumProjectServices, Func<IServiceProvider, IConnectionSerivceDeterminant>>
                {
                    { EnumProjectServices.StandardAutoresponder, x=> x.GetRequiredService<ConnectionSerivceDeterminant<MarketplaceConnectionOpenApiEntity>>()}
                }, serviceProvider));

            services.AddSingleton(typeof(ConnectionSerivceDeterminant<>));
        }
    }
}
