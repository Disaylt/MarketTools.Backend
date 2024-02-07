using Quartz;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var host = builder.Build();
host.Run();
