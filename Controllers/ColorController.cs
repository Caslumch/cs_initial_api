using Microsoft.AspNetCore.Mvc;

namespace SeuNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] ColorRequest request)
        {
            
            if (request == null)
            {
                return BadRequest("Dados inv�lidos.");
            }

            if (string.IsNullOrEmpty(request.ColorName))
            {
                return BadRequest("O nome da cor � obrigat�rio.");
            }

           
            string responseMessage = $"A cor {request.ColorName} tem intensidade {request.Intensity}.";

            return Ok(responseMessage);
        }
    }
}