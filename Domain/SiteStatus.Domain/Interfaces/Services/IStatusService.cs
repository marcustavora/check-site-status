using SiteStatus.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteStatus.Domain.Interfaces.Services
{
    public interface IStatusService
    {
        Task<StatusDTO> Add(StatusDTO input);
        Task<IEnumerable<StatusDTO>> GetAll();
    }
}