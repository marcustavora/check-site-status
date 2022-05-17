using AutoMapper;
using SiteStatus.Domain.Interfaces.Infra;

namespace SiteStatus.Infra.AutoMapper
{
    public class MyMapper : IMyMapper
    {
        private readonly IMapper _mapper;

        public MyMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public T Map<T>(object obj)
        {
            return _mapper.Map<T>(obj);
        }
    }
}