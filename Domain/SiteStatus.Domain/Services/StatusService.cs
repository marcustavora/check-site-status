using SiteStatus.Domain.DTOs;
using SiteStatus.Domain.Entities;
using SiteStatus.Domain.Interfaces.Infra;
using SiteStatus.Domain.Interfaces.Repositories;
using SiteStatus.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteStatus.Domain.Services
{
    public class StatusService : IStatusService
    {
        private readonly IRepository<Status> _statusRepository;
        private readonly IMyMapper _mapper;

        public StatusService(IRepository<Status> statusRepository, IMyMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        public async Task<StatusDTO> Add(StatusDTO input)
        {
            var model = _mapper.Map<Status>(input);
            _statusRepository.Add(model);
            await _statusRepository.SaveChangesAsync();

            return input;
        }

        public async Task<IEnumerable<StatusDTO>> GetAll()
        {
            var models = await _statusRepository.GetAllAsync();
            var results = _mapper.Map<IEnumerable<StatusDTO>>(models);
            return results;
        }
    }
}