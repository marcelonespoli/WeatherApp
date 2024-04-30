using Microsoft.AspNetCore.Mvc;
using Weather.Proxy.Api.Constants;

namespace Weather.Proxy.Api.Controllers
{
    [Route(Routes.Api)]
    public class HealthcheckController : BaseController
    {
        [HttpGet(Routes.HealthCheck)]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
