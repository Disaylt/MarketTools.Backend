using MarketTools.MainDatabaseProvider;
using MarketTools.Persistence;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

string connectionStr = Environment.GetEnvironmentVariable("MpToolsMainDatabase") ?? throw new NullReferenceException();
builder.Services.AddMainDatabase(connectionStr);

var host = builder.Build();
host.Run();
