using MarketTools.Application;
using MarketTools.Domain.Common.Configuration;
using Quartz;
using StandardAutoresponder.WorkerService.Interfaces;
using StandardAutoresponder.WorkerService.Jobs;
using StandardAutoresponder.WorkerService.Services;
using StandardAutoresponder.WorkerService.Utilities;
using MarketTools.Infrastructure;
using MarketTools.Domain.Entities;
using Microsoft.AspNetCore.Identity;

var builder = Host.CreateApplicationBuilder(args);
builder.AddConfiguration();
SequreSettings sequreConfiguration = builder.Configuration.GetSection("Sequre").Get<SequreSettings>()
    ?? throw new NullReferenceException();

builder.Services.AddApplicationLayer();
builder.Services.AddDatabases(sequreConfiguration);
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddHttpClients(sequreConfiguration);

builder.Services.AddScoped<IWbFeedbacksHandler, WbFeedbacksHandler>();
builder.Services.AddScoped<IContextLoader, ContextLoader>();

builder.Services.AddQuartz(opt =>
{
    JobKey jobKey = new JobKey("WB");
    opt.AddJob<WbAutoresponderJob>(x=> x.WithIdentity(jobKey));

    opt.AddTrigger(tOpts => tOpts
        .ForJob(jobKey)
        .WithIdentity($"{jobKey.Name}-t")
        .StartNow()
        .WithSimpleSchedule(scheduleOpt => scheduleOpt
            .WithIntervalInMinutes(10)
            .RepeatForever()));
});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var host = builder.Build();
host.Run();
