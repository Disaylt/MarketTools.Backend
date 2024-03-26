using Microsoft.Extensions.DependencyInjection;
using MarketTools.WebApi.Extensions;
using MarketTools.Infrastructure;
using MarketTools.Application;
using MarketTools.WebApi.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MarketTools.WebApi.Common.Json;
using MarketTools.Domain.Common.Configuration;
using MarketTools.Application.Interfaces.Excel;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebConfiguration();
SequreSettings sequreConfiguration = builder.Configuration.GetSection("Sequre").Get<SequreSettings>()
    ?? throw new NullReferenceException();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCurrentApp();
builder.Services.AddApplicationLayer();
builder.Services.AddMedatorRequests();
builder.Services.AddBaererSwager();

builder.Services.AddDatabases(sequreConfiguration);
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddJwtAuth(sequreConfiguration);
builder.Services.AddInfrasrtuctureIdentity();

builder.Services.AddHttpClients(sequreConfiguration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

}
app.UseWebExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor 
                        | ForwardedHeaders.XForwardedProto
});

string[] corsUrls = sequreConfiguration.CorsUrls.ToArray();
app.UseCors(builder => builder
    .WithOrigins(corsUrls)
    .AllowAnyMethod()
    .AllowAnyHeader()
);

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseWriteAuthHelper();

app.MapControllers();

app.Run();
