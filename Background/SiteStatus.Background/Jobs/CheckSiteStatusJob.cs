using Microsoft.Extensions.Logging;
using Quartz;
using SiteStatus.Domain.DTOs;
using SiteStatus.Domain.Interfaces.Infra;
using SiteStatus.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace SiteStatus.Background.Jobs
{
    public class CheckSiteStatusJob : IJob
    {
        private readonly ILogger<CheckSiteStatusJob> _logger;
        private readonly IHttpRequest _httpRequest;
        private readonly IStatusService _statusService;

        public CheckSiteStatusJob(ILogger<CheckSiteStatusJob> logger, IHttpRequest httpRequest, IStatusService statusService)
        {
            _logger = logger;
            _httpRequest = httpRequest;
            _statusService = statusService;
        }
        
        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Starting new checking site status!");

            var uri = "http://www.google.com";
            var result = await _httpRequest.Get(uri);

            var statusDTO = new StatusDTO(uri, result.IsSuccessStatusCode, DateTime.Now);
            await _statusService.Add(statusDTO);

            var all = await _statusService.GetAll();

            _logger.LogInformation("Finishing new checking site status!");
        }
    }
}