using MarketTools.Application;
using MarketTools.Domain.Common.Configuration;
using Quartz;
using StandardAutoresponder.WorkerService.Interfaces;
using StandardAutoresponder.WorkerService.Jobs;
using StandardAutoresponder.WorkerService.Services;
using MarketTools.Infrastructure;
using MarketTools.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using MarketTools.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);
builder.AddConfiguration();
SequreSettings sequreConfiguration = builder.Configuration.GetSection("Sequre").Get<SequreSettings>()
    ?? throw new NullReferenceException();

builder.Services.AddApplicationLayer();
builder.Services.AddDatabases(sequreConfiguration);
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddHttpClients(sequreConfiguration);

builder.Services.AddScoped<WbAutoresponderHandler>();
builder.Services.AddScoped<OzonAutoresponderHandler>();

builder.Services.AddSingleton(new Dictionary<MarketplaceName, Func<IServiceProvider, IAutoresponderHandler>>
{
    {MarketplaceName.WB, x=> x.GetRequiredService<WbAutoresponderHandler>() },
    {MarketplaceName.OZON, x=> x.GetRequiredService<OzonAutoresponderHandler>() }
});

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
