// See https://aka.ms/new-console-template for more information

//1 Create a Scheduler Factory
    using Quartz;
    using Quartz.Impl;
using QuartzConsole;
using System.Security.Cryptography.X509Certificates;

// 1 Create a scheduler Factory
ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
// 2 Get and Start Scheduler
IScheduler scheduler = await schedulerFactory.GetScheduler();
await scheduler.Start();
//3 Create a Job
IJobDetail job = JobBuilder.Create<GenerateNumberJob>().WithIdentity("Number generator Job", "Number gen Group").Build();
//4 Create a Trigger
ITrigger trigger = TriggerBuilder.Create()
    .WithIdentity("Number generator trigger", "Number generator group")
    .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever()).Build();
// Schedule the job using the job and trigger

await scheduler.ScheduleJob(job,trigger);

Console.ReadKey();

