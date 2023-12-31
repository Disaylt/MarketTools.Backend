using Microsoft.Extensions.DependencyInjection;
using MarketTools.WebApi.Extensions;
using MarketTools.Infrastructure;
using MarketTools.Application;
using MarketTools.WebApi.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MarketTools.WebApi.Common.Json;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebConfiguration();

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new StringJsonConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCurrentApp();
builder.Services.AddApplicationLayer();
builder.Services.AddBaererSwager();

string connectionMainDb = builder.Configuration["Sequre:DatabaseConnections:Main"] ?? throw new NullReferenceException();
builder.Services.AddDatabases(connectionMainDb);
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddInfrasrtuctureIdentity();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

}
app.UseMiddleware<WebExeptionHandlerMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(builder => builder
    .WithOrigins(
        "http://localhost:4200"
    )
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.SetUserIdToAuthHelper();

app.MapControllers();

app.Run();
