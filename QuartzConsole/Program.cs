// See https://aka.ms/new-console-template for more information

//1 Create a Scheduler Factory
using Quartz;
using Quartz.Impl;
using QuartzConsole.Jobs;


// 1 Create a scheduler Factory
ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
// 2 Get and Start Scheduler
IScheduler scheduler = await schedulerFactory.GetScheduler();
await scheduler.Start();
//3 Create a Job
IJobDetail job = JobBuilder.Create<GenerateNumberJob>()
    .WithIdentity("Number generator Job", "Number gen Group")
    .Build();

IJobDetail job2 = JobBuilder.Create<ShowListJob>()
    .WithIdentity("List of Name Personne", "personn generator Group")
    .Build();

IJobDetail job3 = JobBuilder.Create<ReadJsonPersonnJob>()
    .WithIdentity("Read Json Personn", "json Personn generator Group")
    .Build();



//4 Create a Trigger
ITrigger trigger = TriggerBuilder.Create()
    .WithIdentity("Number generator trigger", "Number generator group")
    .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever()).Build();

ITrigger trigger2 = TriggerBuilder.Create()
    .WithIdentity("List of Name Personne trigger", "List of Name Personne grouo")
    .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).WithRepeatCount(0)).Build();

ITrigger trigger3 = TriggerBuilder.Create()
    .ForJob(job2)
    .StartNow()
    .WithCronSchedule("0 0/1 * 1/1 * ? *")
    .WithIdentity("List of Name Personne trigger", "List of Name Personne grouo")
    .Build();

ITrigger trigger4 = TriggerBuilder.Create()
    .ForJob(job3)
    .StartNow()
    .WithIdentity("Json personne  trigger", "Json personne group")
    .Build();

// Schedule the job using the job and trigger

await scheduler.ScheduleJob(job,trigger);
await scheduler.ScheduleJob(job2, trigger3);
await scheduler.ScheduleJob(job3, trigger4);
Console.ReadKey();

