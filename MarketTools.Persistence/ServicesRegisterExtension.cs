using MarketTools.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Persistence
{
    public static class ServicesRegisterExtension
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection serviceDescriptors)
        {

            return serviceDescriptors;
        }

        public static IServiceCollection AddMainDatabase(this IServiceCollection serviceDescriptors, string connection)
        {
            serviceDescriptors.AddDbContext<MainAppDbContext>(options =>
                options.UseNpgsql(connection));

            return serviceDescriptors;
        }
    }
}
