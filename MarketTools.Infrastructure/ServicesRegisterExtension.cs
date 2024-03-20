using MarketTools.Application.Interfaces.Database;
using MarketTools.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Infrastructure.Identity;
using Microsoft.Extensions.Configuration;
using MarketTools.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using MarketTools.Application.Interfaces.Excel;
using MarketTools.Domain.Interfaces.Limits;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Common.Constants;
using MarketTools.Domain.Common.Configuration;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Infrastructure.Common;
using MarketTools.Infrastructure.Autoresponder.Standard.Services;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Infrastructure.User.Notifications;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Infrastructure.Exceptions;
using MarketTools.Infrastructure.MarketplaceConnections.Services;
using MarketTools.Domain.Enums;
using MarketTools.Application.Interfaces.Http.Wb;
using MarketTools.Application.Interfaces.Http.Wb.Seller;
using MarketTools.Infrastructure.Http;
using MarketTools.Application.Models.Http.WB.Seller;
using MarketTools.Infrastructure.Http.Reqeusts.Wb;
using MarketTools.Infrastructure.Http.Reqeusts.Wb.Seller.Api;
using MarketTools.Application.Interfaces.MarketplaceConnections.WB.Seller.Api;
using MarketTools.Infrastructure.Http.Clients;
using MarketTools.Application.Interfaces.MarketplaceConnections.Ozon.Seller.Account;
using MarketTools.Infrastructure.MarketplaceConnections;
using MarketTools.Application.Interfaces.Http.Wb.Seller.Api;
using MarketTools.Application.Interfaces.Feedbacks;
using MarketTools.Infrastructure.Feedbacks.WB.Seller.Api;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Infrastructure.ProjectServices.ServiceFactories;
using MarketTools.Infrastructure.MarketplaceConnections.Services.OZON.Seller.Account;
using MarketTools.Infrastructure.MarketplaceConnections.Services.WB.Seller.Api;
using MarketTools.Infrastructure.Http.Proxy;
using MarketTools.Application.Models.Http.Ozon.Seller.Account.Feedbacks;
using MarketTools.Infrastructure.Http.ContentConverters.Ozon.Seller.Account.Feedbacks;
using MarketTools.Infrastructure.Feedbacks.Ozon.Seller.Account;
using MarketTools.Application.Interfaces.Http.Ozon.Seller.Account;
using MarketTools.Infrastructure.Http.Reqeusts.Ozon.Seller.Account;

namespace MarketTools.Infrastructure
{
    public static class ServicesRegisterExtension
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddScoped<IIdentityContextLoadService, IdentityContextLoadService>();
            serviceDescriptors.AddScoped<ITokenService, JwtTokenService>();
            serviceDescriptors.AddSingleton<ILimitsService<IStandarAutoresponderLimits>, StandardAutoresponderBaseLimitationsService>();
            serviceDescriptors.AddSingleton<ILimitsService<IMarketplaceConnectionLimits>, MarketplaceConnectionsLimitsService>();

            serviceDescriptors.AddScoped<IAutoresponderResponseService, AutoresponderResponseService>();
            serviceDescriptors.AddScoped<IAutoresponderConnectionsService, AutoresponderConnectionsService>();
            serviceDescriptors.AddScoped<IAutoresponderReportsService, AutoresponderReportsService>();
            serviceDescriptors.AddScoped<IAutoresponderContextLoadService, AutoresponderContextLoadService>();
            serviceDescriptors.AddSingleton<IExcelReader<StandardAutoresponderRecommendationProductEntity>, RecommendationProductsExcelConverterService>();
            serviceDescriptors.AddSingleton<IExcelWriter<StandardAutoresponderRecommendationProductEntity>, RecommendationProductsExcelConverterService>();

            serviceDescriptors.AddScoped(typeof(IContextService<>), typeof(ContextService<>));

            serviceDescriptors.AddScoped<IExceptionHandleService<AppConnectionBadRequestException>, HttpExceptionHandleService>();

            serviceDescriptors.AddScoped<IUserNotificationsService, UserNotificationsService>();

            serviceDescriptors.AddScoped<IMarketplaceConnectionService, MarketplaceConnectionService>();

            serviceDescriptors.AddScoped<IConnectionConverterFactory<IWbSellerApiConnectionConverter>, WbSellerApiConnectionConverterFactory>();
            serviceDescriptors.AddScoped<IConnectionConverterFactory<IOzonSellerAccountConnectionConverter>, OzonSellerAccountConnectionConverterFactory>();

            serviceDescriptors.AddSingleton<IHttpContentConverter<FeedbacksRequestBody>, OzonSellerAccountFeedbacksRequestBodyConverter>();
            serviceDescriptors.AddSingleton<IHttpContentConverter<AnswerRequestBody>, OzonSellerAccountAnswerRequesstBodyConverter>();

            AddSolutionMapping(serviceDescriptors);

            serviceDescriptors.AddSingleton<IConnectionDefinitionService, ConnectionDefinitionService>();
            serviceDescriptors.AddScoped<IConnectionActivator, ConnectionActivator>();

            serviceDescriptors.AddScoped(typeof(IConnectionServiceFactory<>), typeof(ConnectionServiceFactory<>));

            serviceDescriptors.AddScoped<WbSellerApiFeedbacksService>();
            serviceDescriptors.AddScoped<OzonSellerAccountFeedbacksService>();
            serviceDescriptors.AddSingleton(new Dictionary<MarketplaceName, Dictionary<MarketplaceConnectionType, Func<IServiceProvider, IFeedbacksService>>>
            {
                {MarketplaceName.WB, new Dictionary<MarketplaceConnectionType, Func<IServiceProvider, IFeedbacksService>>
                    {
                        {MarketplaceConnectionType.OpenApi, x=> x.GetRequiredService<WbSellerApiFeedbacksService>() }
                    } 
                },
                {MarketplaceName.OZON, new Dictionary<MarketplaceConnectionType, Func<IServiceProvider, IFeedbacksService>>
                    {
                        {MarketplaceConnectionType.Account, x=> x.GetRequiredService<OzonSellerAccountFeedbacksService>() }
                    }
                }
            });

            serviceDescriptors.AddScoped(typeof(IProjectServiceFactory<>), typeof(ProjectServiceFactory<>));

            serviceDescriptors.AddScoped<StandardAutoresponderValidator>();
            serviceDescriptors.AddSingleton(new Dictionary<EnumProjectServices, Func<IServiceProvider, IProjectServiceValidator>>
            {
                {EnumProjectServices.StandardAutoresponder, x=> x.GetRequiredService<StandardAutoresponderValidator>() }
            });

            return serviceDescriptors;
        }

        public static IServiceCollection AddHttpClients(this IServiceCollection serviceDescriptors, SequreSettings sequreSettings)
        {
            serviceDescriptors.AddScoped<IHttpConnectionContextService, HttpConnectionContextService>();
            serviceDescriptors.AddSingleton<IProxyService, OptionsProxyService>();
            serviceDescriptors.AddSingleton<IProxyConverter, SobotProxyConverter>();

            serviceDescriptors.AddHttpClient<WbOpenApiHttpConnectionClient>();
            serviceDescriptors.AddScoped<OzonSellerAccountHttpConnectionClient>();
            serviceDescriptors.AddSingleton(new Dictionary<MarketplaceName, Dictionary<MarketplaceConnectionType, Func<IServiceProvider, IHttpConnectionClient>>>
            {
                {MarketplaceName.WB, new Dictionary<MarketplaceConnectionType, Func<IServiceProvider, IHttpConnectionClient>>
                    {
                        { MarketplaceConnectionType.OpenApi, x => x.GetRequiredService<WbOpenApiHttpConnectionClient>() }
                    }
                },
                { MarketplaceName.OZON, new Dictionary<MarketplaceConnectionType, Func<IServiceProvider, IHttpConnectionClient>>
                    {
                        { MarketplaceConnectionType.Account, x=> x.GetRequiredService<OzonSellerAccountHttpConnectionClient>() }
                    }
                }
            });

            serviceDescriptors.AddScoped<IWbSellerApiFeedbacksService, SellerApiFeedbacksHttpService>();
            serviceDescriptors.AddScoped<IOzonSellerAccountFeedbacksHttpService, OzonSellerAccountFeedbacksHttpService>();

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
