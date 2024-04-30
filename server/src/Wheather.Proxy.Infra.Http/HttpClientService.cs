using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using Wheather.Proxy.Domain.Interfaces;
using Wheather.Proxy.Infra.Config;

namespace Wheather.Proxy.Infra.Http
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _options;
        private readonly ILogger<HttpClientService> _logger;

        public HttpClientService(
            IOptions<ApiSettings> options,
            ILogger<HttpClientService> logger)
        {
            _httpClient = new HttpClient();
            _options = options.Value;
            _logger = logger;
        }

        public async Task<HttpResponseMessage> Get(string uri)
        {
            try
            {
                _logger.LogInformation($"Request data for URI = {uri}");

                PrepareRequestHeaders();
                return await _httpClient.GetAsync(uri);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error to request data for URI = {uri} - Error Message: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        private void PrepareRequestHeaders()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _options.XRapidApiKey);
        }
        
    }
}
