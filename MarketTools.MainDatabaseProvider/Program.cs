using MarketTools.Infrastructure;
using MarketTools.MainDatabaseProvider;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

string pathToJsonSettings = Environment.GetEnvironmentVariable("MpToolsSettingsPath") ?? throw new NullReferenceException();
builder.Configuration.AddJsonFile($"{pathToJsonSettings}\\sequreconfig.{builder.Environment.EnvironmentName}.json", false);

string connectionStr = builder.Configuration["sequre:DatabaseConnections:Main"] ?? throw new NullReferenceException();

builder.Services.AddMainDatabase(connectionStr);

var host = builder.Build();
host.Run();
