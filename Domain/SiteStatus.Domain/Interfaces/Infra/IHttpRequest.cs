using System.Net.Http;
using System.Threading.Tasks;

namespace SiteStatus.Domain.Interfaces.Infra
{
    public interface IHttpRequest
    {
        Task<HttpResponseMessage> Get(string uri);
    }
}