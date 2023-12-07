using Microsoft.Extensions.DependencyInjection;
using MarketTools.WebApi.Extensions;
using MarketTools.Infrastructure;
using MarketTools.Application;
using MarketTools.WebApi.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebConfiguration();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCurrentApp();
builder.Services.AddApplicationLayer();
builder.Services.AddBaererSwager();

string connectionMainDb = builder.Configuration["Sequre:DatabaseConnections:Main"] ?? throw new NullReferenceException();
builder.Services.AddMainDatabase(connectionMainDb);
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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.SetUserIdToAuthHelper();

app.MapControllers();

app.Run();
