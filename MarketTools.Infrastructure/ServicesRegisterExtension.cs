﻿using MarketTools.Application.Interfaces.Database;
using MarketTools.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Infrastructure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MarketTools.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Infrastructure.Services.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Excel;
using MarketTools.Application.Interfaces;
using MarketTools.Domain.Interfaces.Limits;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Common.Constants;
using MarketTools.Domain.Common.Configuration;

namespace MarketTools.Infrastructure
{
    public static class ServicesRegisterExtension
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddScoped<AuthHelper>();
            serviceDescriptors.AddScoped<IAuthReadHelper>(provider => provider.GetRequiredService<AuthHelper>());
            serviceDescriptors.AddScoped<IAuthWriteHelper>(provider => provider.GetRequiredService<AuthHelper>());
            serviceDescriptors.AddScoped<ITokenService, JwtTokenService>();
            serviceDescriptors.AddSingleton<ILimitsService<IStandarAutoresponderLimits>, StandardAutoresponderBaseLimitationsService>();

            serviceDescriptors.AddSingleton<IExcelReader<StandardAutoresponderRecommendationProduct>, RecommendationProductsExcelConverterService>();
            serviceDescriptors.AddSingleton<IExcelWriter<StandardAutoresponderRecommendationProduct>, RecommendationProductsExcelConverterService>();

            AddSolutionMapping(serviceDescriptors);

            return serviceDescriptors;
        }

        public static IServiceCollection AddDatabases(this IServiceCollection serviceDescriptors, SequreSettings sequreSettings)
        {
            serviceDescriptors.AddNpgsql<MainAppDbContext>(sequreSettings.Database.MainConnectionString);
            serviceDescriptors.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceDescriptors.AddScoped<IAuthUnitOfWork, AuthUnitOfWork>();

            return serviceDescriptors;
        }

        public static IServiceCollection AddInfrasrtuctureIdentity(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddIdentityCore<AppIdentityUser>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<MainAppDbContext>()
            .AddDefaultTokenProviders();

            return serviceDescriptors;
        }

        private static void AddSolutionMapping(IServiceCollection serviceDescriptors)
        {
            IEnumerable<Assembly> solutionAsemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(x => x.FullName != null && x.FullName.Contains(SolutionConstants.SolutionName));
            foreach (Assembly assembly in solutionAsemblies)
            {
                serviceDescriptors.AddAutoMapper(config =>
                {
                    config.AddProfile(new AssemblyMappingProfile(assembly));
                });
            }
        }
    }
}
