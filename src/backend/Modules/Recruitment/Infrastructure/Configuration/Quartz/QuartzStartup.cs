using LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Inbox;
using LinkedChain.Modules.Recruitment.Infrastructure.Configuration.InternalCommands;
using Quartz.Impl;
using Quartz;
using System.Collections.Specialized;
using Serilog;
using Quartz.Logging;
using LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Outbox;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Quartz;

internal static class QuartzStartup
{
    private static IScheduler? _scheduler;

    internal static void Initialize(ILogger logger, long? internalProcessingPoolingInterval)
    {
        logger.Information("Quartz starting...");

        var schedulerConfiguration = new NameValueCollection
        {
            { "quartz.scheduler.instanceName", "Recruitment" }
        };

        ISchedulerFactory schedulerFactory = new StdSchedulerFactory(schedulerConfiguration);
        _scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();

        LogProvider.SetCurrentLogProvider(new SerilogLogProvider(logger));

        _scheduler.Start().GetAwaiter().GetResult();

        var processOutboxJob = JobBuilder.Create<ProcessOutboxJob>().Build();

        ITrigger trigger;
        if (internalProcessingPoolingInterval.HasValue)
        {
            trigger =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithSimpleSchedule(x =>
                        x.WithInterval(TimeSpan.FromMilliseconds(internalProcessingPoolingInterval.Value))
                            .RepeatForever())
                    .Build();
        }
        else
        {
            trigger =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithCronSchedule("0/2 * * ? * *")
                    .Build();
        }

        _scheduler
            .ScheduleJob(processOutboxJob, trigger)
            .GetAwaiter().GetResult();

        var processInboxJob = JobBuilder.Create<ProcessInboxJob>().Build();

        ITrigger processInboxTrigger;
        if (internalProcessingPoolingInterval.HasValue)
        {
            processInboxTrigger =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithSimpleSchedule(x =>
                        x.WithInterval(TimeSpan.FromMilliseconds(internalProcessingPoolingInterval.Value))
                            .RepeatForever())
                    .Build();
        }
        else
        {
            processInboxTrigger =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithCronSchedule("0/2 * * ? * *")
                    .Build();
        }

        _scheduler
            .ScheduleJob(processInboxJob, processInboxTrigger)
            .GetAwaiter().GetResult();

        var processInternalCommandsJob = JobBuilder.Create<ProcessInternalCommandsJob>().Build();

        ITrigger triggerCommandsProcessing;
        if (internalProcessingPoolingInterval.HasValue)
        {
            triggerCommandsProcessing =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithSimpleSchedule(x =>
                        x.WithInterval(TimeSpan.FromMilliseconds(internalProcessingPoolingInterval.Value))
                            .RepeatForever())
                    .Build();
        }
        else
        {
            triggerCommandsProcessing =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithCronSchedule("0/2 * * ? * *")
                    .Build();
        }

        _scheduler.ScheduleJob(processInternalCommandsJob, triggerCommandsProcessing).GetAwaiter().GetResult();

        logger.Information("Quartz started.");
    }

    internal static void StopQuartz()
    {
        _scheduler?.Shutdown();
    }
}