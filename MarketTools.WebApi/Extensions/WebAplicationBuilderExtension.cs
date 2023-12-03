﻿using MarketTools.Application.Models.Common;

namespace MarketTools.WebApi.Extensions
{
    public static class WebAplicationBuilderExtension
    {
        public static WebApplicationBuilder AddWebConfiguration(this WebApplicationBuilder builder)
        {
            builder.Configuration
                .AddJsonFile(
                $"additions/sequreconfig.{builder.Environment.EnvironmentName}.json",
                false);
            builder.Services.Configure<SequreSettings>(builder.Configuration.GetSection("sequre"));

            return builder;
        }
    }
}
