using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SiteStatus.Domain.Interfaces.Infra;
using SiteStatus.Domain.Interfaces.Repositories;
using SiteStatus.Domain.Interfaces.Services;
using SiteStatus.Domain.Services;
using SiteStatus.Infra.AutoMapper;
using SiteStatus.Infra.Data;
using SiteStatus.Infra.Data.Repositories;
using SiteStatus.Infra.Http;

namespace SiteStatus.Infra.Extensions
{
    public static class ServicesExtensions
    {
        public static void UseDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IStatusService, StatusService>();
        }

        public static void UseRepository(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(opts => opts.UseInMemoryDatabase("InMemoryDataBase"));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static void UseAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MyMapper));
            services.AddScoped<IMyMapper, MyMapper>();
        }

        public static void UseHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient<IHttpRequest, HttpRequest>(client =>
            {
                client.DefaultRequestHeaders.Accept.Clear();
            });
        }
    }
}