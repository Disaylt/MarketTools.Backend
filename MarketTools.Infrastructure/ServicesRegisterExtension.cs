using MarketTools.Application.Interfaces.Database;
using MarketTools.Infrastructure.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure
{
    public static class ServicesRegisterExtension
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection serviceDescriptors)
        {
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
