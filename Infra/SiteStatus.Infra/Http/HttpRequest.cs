using SiteStatus.Domain.Interfaces.Infra;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SiteStatus.Infra.Http
{
    public class HttpRequest : IHttpRequest
    {
        private HttpClient _httpClient;

        public HttpRequest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Get(string uri)
        {
            var builder = new UriBuilder(uri);

            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(builder.ToString())
            };

            var result = await _httpClient.SendAsync(httpRequest);

            return result;
        }
    }
}