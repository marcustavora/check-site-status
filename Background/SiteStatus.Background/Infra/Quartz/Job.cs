using Quartz;
using SiteStatus.Background.Config.Interfaces;
using System;

namespace SiteStatus.Background.Infra.Quartz
{
    public class Job
    {
        #region [ Constructors ]

        public Job()
        {
        }

        public Job(IConfigBase config, Type jobType, string jobName = null)
        {
            Config = config;
            JobType = jobType;
            JobName = string.IsNullOrEmpty(jobName) ? jobType.ToString() : jobName;
            CreateJob();
        }

        #endregion

        #region [ Properties ]

        public IConfigBase Config { get; set; }

        public Type JobType { get; set; }

        public string JobName { get; set; }

        public IJobDetail JobDetail { get; set; }

        public ITrigger Trigger { get; set; }

        #endregion

        #region [ Methods ]

        public void CreateJob()
        {
            JobDetail = JobBuilder.Create(JobType)
                                  .WithIdentity(JobName)
                                  .Build();

            if (Config.IsInterval)
                CreateTriggerInterval();

            if (Config.IsRecurrence)
                CreateTriggerRecurrence();
        }

        private void CreateTriggerInterval()
        {
            Trigger = TriggerBuilder.Create()
                                    .WithIdentity(new TriggerKey(JobName, "Principal"))
                                    .StartNow()
                                    .WithSimpleSchedule(x =>
                                    {
                                        switch (Config.Interval.Unit)
                                        {
                                            case EUnitOfTime.Seconds:
                                                x.WithIntervalInSeconds(Config.Interval.Time).RepeatForever();
                                                break;
                                            case EUnitOfTime.Minutes:
                                                x.WithIntervalInMinutes(Config.Interval.Time).RepeatForever();
                                                break;
                                            case EUnitOfTime.Hours:
                                            default:
                                                x.WithIntervalInHours(Config.Interval.Time).RepeatForever();
                                                break;
                                        }
                                    })
                                    .Build();
        }

        private void CreateTriggerRecurrence()
        {
            Trigger = TriggerBuilder.Create()
                                    .WithIdentity(new TriggerKey(JobName, "Principal"))
                                    .WithCronSchedule(Config.Recurrence.Cron)
                                    .Build();
        }

        #endregion
    }
}