using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Weather.Proxy.Api.Constants;
using Wheather.Proxy.Domain.Interfaces;
using Wheather.Proxy.Infra.Config;

namespace Weather.Proxy.Api.Controllers
{
    [Route(Routes.Api)]
    public class AstronomyController : BaseController
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ApiSettings _options;

        public AstronomyController(
            IHttpClientService httpClientService,
            IOptions<ApiSettings> options)
        {
            _httpClientService = httpClientService;
            _options = options.Value;
        }

        [HttpGet(Routes.Astronomy)]
        public async Task<IActionResult> Get(string city)
        {
            var requestUri = $"{_options.BaseUrl}/astronomy.json?q={city}";
            var messsage = await _httpClientService.Get(requestUri);
            return await Response(messsage);
        }

    }
}
