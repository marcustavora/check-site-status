using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;
using System.Runtime.CompilerServices;

namespace SiteStatus.Background.Infra.Quartz
{
    public class JobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private ConditionalWeakTable<IJob, IServiceScope> _scopes;

        #region [ Constructors ]

        public JobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _scopes = new ConditionalWeakTable<IJob, IServiceScope>();
        }

        #endregion

        #region [ Properties ]


        #endregion

        #region [ Methods ]

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var scope = _serviceProvider.GetService<IServiceScopeFactory>().CreateScope();
            var job = (IJob)scope.ServiceProvider.GetService(bundle.JobDetail.JobType);
            _scopes.Add(job, scope);
            return job;
        }

        public void ReturnJob(IJob job)
        {
        }

        #endregion
    }
}