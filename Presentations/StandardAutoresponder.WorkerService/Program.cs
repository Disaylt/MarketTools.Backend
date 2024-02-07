using Quartz;
using StandardAutoresponder.WorkerService.Interfaces;
using StandardAutoresponder.WorkerService.Jobs;
using StandardAutoresponder.WorkerService.Utilities;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IWbAutoresponderHandler, WbAutoresponderHandler>();

builder.Services.AddQuartz(opt =>
{
    JobKey jobKey = new JobKey("WB");
    opt.AddJob<WbAutoresponderJob>(x=> x.WithIdentity(jobKey));

    opt.AddTrigger(tOpts => tOpts
        .ForJob(jobKey)
        .WithIdentity($"{jobKey.Name}-t")
        .StartNow()
        .WithSimpleSchedule(scheduleOpt => scheduleOpt
            .WithIntervalInSeconds(2)
            .RepeatForever()));
});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var host = builder.Build();
host.Run();
