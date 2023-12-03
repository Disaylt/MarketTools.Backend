using MarketTools.Application.Models.Common;
using Microsoft.Extensions.DependencyInjection;
using MarketTools.Persistence;
using MarketTools.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddWebConfiguration();
builder.Services.AddCurrentApp();
builder.Services.AddPersistenceLayer();

string connectionMainDb = builder.Configuration["sequre:DatabaseConnections:Main"] ?? throw new NullReferenceException();
builder.Services.AddMainDatabase(connectionMainDb);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
