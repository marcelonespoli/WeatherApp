using Microsoft.AspNetCore.Mvc;

namespace Weather.Proxy.Api.Controllers
{
    [Route("api")]
    public class HealthcheckController : BaseController
    {
        [HttpGet("healthcheck")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
