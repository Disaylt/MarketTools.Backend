using MarketTools.Application.Common.Configuration;

namespace MarketTools.WebApi.Extensions
{
    public static class WebAplicationBuilderExtension
    {
        public static WebApplicationBuilder AddWebConfiguration(this WebApplicationBuilder builder)
        {
            builder.Configuration
                .AddJsonFile(
                $"{builder.Configuration.GetValue<string>("MpToolsSettingsPath")}sequreconfig.{builder.Environment.EnvironmentName}.json",
                false);
            builder.Services.Configure<SequreSettings>(builder.Configuration.GetSection("Sequre"));
            
            return builder;
        }
    }
}