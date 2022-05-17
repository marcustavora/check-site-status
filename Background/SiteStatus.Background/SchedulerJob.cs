using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Quartz;
using SiteStatus.Background.Config;
using SiteStatus.Background.Infra.Quartz;
using SiteStatus.Background.Jobs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SiteStatus.Background
{
    public class SchedulerJob : IHostedService
    {
        private readonly IScheduler _scheduler;
        private readonly List<Job> _jobs;
        private readonly ConfigSiteStatus _configSiteStatus;

        public SchedulerJob(IScheduler scheduler,
                            IOptions<ConfigSiteStatus> configSiteStatus)
        {
            _scheduler = scheduler;
            _configSiteStatus = configSiteStatus.Value;
            _jobs = new List<Job>();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _jobs.Add(new Job(_configSiteStatus, typeof(CheckSiteStatusJob)));
            _jobs.ForEach(job => _scheduler.ScheduleJob(job.JobDetail, job.Trigger, cancellationToken).GetAwaiter());

            await _scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _scheduler.Shutdown();
        }
    }
}