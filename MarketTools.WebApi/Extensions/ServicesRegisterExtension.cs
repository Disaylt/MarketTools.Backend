
using FluentValidation;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Common.Configuration;
using MarketTools.Domain.Entities;
using MarketTools.Infrastructure.Database;
using MarketTools.WebApi.Common.Json;
using MarketTools.WebApi.Interfaces;
using MarketTools.WebApi.Services.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            serviceDescriptors.AddScoped<IWebExceptionHandlerService<ValidationException>, ValidationExceptionHandlerService>();
            serviceDescriptors.AddScoped<IWebExceptionHandlerService<Exception>, DefaultBadRequestExceptionHandlerService>();
            serviceDescriptors.AddScoped<IWebExceptionHandlerService<AppNotFoundException>, DefaultNotFoundExceptionHandlerService>();
            serviceDescriptors.AddScoped<IWebExceptionHandlerService<IdentityUnauthorizedException>, IdentityUnauthorizedExceptionHandler>();
            serviceDescriptors.AddScoped<IWebExceptionHandlerService<DbUpdateException>, EntityFrameworkExceptionHandlerService>();

            serviceDescriptors.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.Converters.Add(new StringJsonConverter());
                });

            return serviceDescriptors;
        }

        public static IServiceCollection AddJwtAuth(this IServiceCollection serviceDescriptors, SequreSettings sequreSettings)
        {
            byte[] secretBytes = Encoding.UTF8.GetBytes(sequreSettings.Jwt.Secret);

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
                        ValidAudience = sequreSettings.Jwt.ValidAudience,
                        ValidIssuer = sequreSettings.Jwt.ValidIssuer,
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
