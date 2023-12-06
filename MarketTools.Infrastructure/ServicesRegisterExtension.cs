using MarketTools.Application.Interfaces.Database;
using MarketTools.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Infrastructure.Identity;

namespace MarketTools.Infrastructure
{
    public static class ServicesRegisterExtension
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<AuthHelper>();
            serviceDescriptors.AddScoped<IAuthReadHelper>(provider => provider.GetRequiredService<AuthHelper>());
            serviceDescriptors.AddScoped<IAuthWriteHelper>(provider => provider.GetRequiredService<AuthHelper>());

            serviceDescriptors.AddMediatR(x=> x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return serviceDescriptors;
        }

        public static IServiceCollection AddMainDatabase(this IServiceCollection serviceDescriptors, string connection)
        {
            serviceDescriptors.AddDbContext<IMainDatabaseContext, MainAppDbContext>(options =>
                options.UseNpgsql(connection));

            return serviceDescriptors;
        }
    }
}
