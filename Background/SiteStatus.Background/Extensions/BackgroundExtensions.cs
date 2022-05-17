using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using SiteStatus.Background.Config;
using SiteStatus.Background.Infra.Quartz;
using SiteStatus.Background.Jobs;

namespace SiteStatus.Background.Extensions
{
    public static class BackgroundExtensions
    {
        public static void UseQuartz(this IServiceCollection services)
        {
            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();
            });
        }

        public static void UseScheduler(this IServiceCollection services)
        {
            services.AddSingleton(s =>
            {
                var sched = new StdSchedulerFactory().GetScheduler().GetAwaiter().GetResult();
                sched.JobFactory = new JobFactory(s);
                return sched;
            });
        }

        public static void UseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConfigSiteStatus>(configuration.GetSection(nameof(ConfigSiteStatus)));
        }

        public static void UseJobs(this IServiceCollection services)
        {
            services.AddScoped<CheckSiteStatusJob>();
        }
    }
}