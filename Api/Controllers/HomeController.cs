using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Hearth()
        {
            return Ok();
        }
    }
}