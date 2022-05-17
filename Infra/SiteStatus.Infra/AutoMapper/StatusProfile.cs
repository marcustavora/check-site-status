using AutoMapper;
using SiteStatus.Domain.DTOs;
using SiteStatus.Domain.Entities;

namespace SiteStatus.Infra.AutoMapper
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<StatusDTO, Status>();
            CreateMap<Status, StatusDTO>();
        }
    }
}