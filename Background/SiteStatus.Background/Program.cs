using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using SiteStatus.Background.Extensions;
using SiteStatus.Infra.Extensions;
using System;

namespace SiteStatus.Background
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args);
            var app = builder.Build();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, config) =>
            {
                config
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appSettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            })
            .ConfigureServices((hostContext, services) =>
            {
                var configuration = hostContext.Configuration;
                services.UseConfiguration(configuration);
                services.UseDomainServices();
                services.UseRepository();
                services.UseAutoMapper();
                services.UseHttpClient();
                services.UseJobs();
                services.UseQuartz();
                services.UseScheduler();

                services.AddHostedService<SchedulerJob>();

            })
            .UseWindowsService()
            .UseSerilog((hostContext, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration);
            });
              
    }
}