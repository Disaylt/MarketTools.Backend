using MarketTools.Application.Interfaces.Database;
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

            return serviceDescriptors;
        }

        public static IServiceCollection AddMainDatabase(this IServiceCollection serviceDescriptors, string connection)
        {
            serviceDescriptors.AddDbContext<IMainDatabaseContext, MainAppDbContext>(options =>
                options.UseNpgsql(connection));

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

        public static IServiceCollection AddJwtAuth(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            IConfigurationSection jwtSeciton = configuration.GetRequiredSection("Sequre")
                .GetRequiredSection("Jwt");
            byte[] secret = Encoding.UTF8.GetBytes(jwtSeciton.GetValue<string>("Secret") ?? throw new NullReferenceException("JWT secret is null"));
            serviceDescriptors.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = jwtSeciton.GetValue<string>("ValidAudience"),
                        ValidIssuer = jwtSeciton.GetValue<string>("ValidIssuer"),
                        IssuerSigningKey = new SymmetricSecurityKey(secret)
                    };
                };
            });

            return serviceDescriptors;
        }
    }
}
