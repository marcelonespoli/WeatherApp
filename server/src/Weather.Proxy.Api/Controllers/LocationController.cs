using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Weather.Proxy.Api.Constants;
using Wheather.Proxy.Domain.Interfaces;
using Wheather.Proxy.Infra.Config;

namespace Weather.Proxy.Api.Controllers
{
    [Route(Routes.Api)]
    public class LocationController : BaseController
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ApiSettings _options;

        public LocationController(
            IHttpClientService httpClientService,
            IOptions<ApiSettings> options)
        {
            _httpClientService = httpClientService;
            _options = options.Value;
        }

        [HttpGet(Routes.Location)]
        public async Task<IActionResult> Get(string city)
        {
            var requestUri = $"{_options.BaseUrl}/timezone.json?q={city}";
            var messsage = await _httpClientService.Get(requestUri);
            return await Response(messsage);
        }

    }
}
