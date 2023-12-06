using Microsoft.Extensions.DependencyInjection;
using MarketTools.WebApi.Extensions;
using MarketTools.Infrastructure;
using MarketTools.Application;
using MarketTools.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddWebConfiguration();
builder.Services.AddCurrentApp();
builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddInfrasrtuctureIdentity();
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddApplicationLayer();

string connectionMainDb = builder.Configuration["sequre:DatabaseConnections:Main"] ?? throw new NullReferenceException();
builder.Services.AddMainDatabase(connectionMainDb);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

}
app.UseMiddleware<WebExeptionHandlerMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.SetUserIdToAuthHelper();

app.MapControllers();

app.Run();
