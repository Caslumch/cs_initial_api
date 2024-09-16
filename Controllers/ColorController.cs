using Microsoft.AspNetCore.Mvc;

namespace SeuNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("essa é a cor ta");
        }
    }
}