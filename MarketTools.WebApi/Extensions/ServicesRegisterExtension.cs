
using FluentValidation;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Entities;
using MarketTools.Infrastructure.Database;
using MarketTools.WebApi.Interfaces;
using MarketTools.WebApi.Services.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

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
            serviceDescriptors.AddScoped<IWebExceptionHandlerService<AppBadRequestException>, DefaultBadRequestExceptionHandlerService>();
            serviceDescriptors.AddScoped<IWebExceptionHandlerService<AppNotFoundException>, DefaultNotFoundExceptionHandlerService>();
            serviceDescriptors.AddScoped<IWebExceptionHandlerService<IdentityUnauthorizedException>, IdentityUnauthorizedExceptionHandler>();


            return serviceDescriptors;
        }

        public static IServiceCollection AddJwtAuth(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            IConfigurationSection jwtSeciton = configuration.GetRequiredSection("Sequre")
                .GetRequiredSection("Jwt");

            string? validAudience = jwtSeciton.GetValue<string>("ValidAudience");
            string? validIssuer = jwtSeciton.GetValue<string>("ValidIssuer");
            string secret = jwtSeciton.GetValue<string>("Secret") ?? throw new NullReferenceException("JWT secret is null");
            byte[] secretBytes = Encoding.UTF8.GetBytes(secret);

            serviceDescriptors.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                {
                    options.IncludeErrorDetails = true;
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidAudience = validAudience,
                        ValidIssuer = validIssuer,
                        IssuerSigningKey = new SymmetricSecurityKey(secretBytes)
                    };
                };
            });

            return serviceDescriptors;
        }

        public static IServiceCollection AddBaererSwager(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                options.EnableAnnotations();
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return serviceDescriptors;
        }
    }
}
