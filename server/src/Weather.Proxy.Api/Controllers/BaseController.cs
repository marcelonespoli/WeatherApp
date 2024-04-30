using Microsoft.AspNetCore.Mvc;

namespace Weather.Proxy.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public abstract class BaseController : Controller
    {
        protected new async Task<IActionResult> Response(HttpResponseMessage response)
        {
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }            
            return BadRequest(new
            {
                success = false,
                errors = result
            });
        }
    }
}
