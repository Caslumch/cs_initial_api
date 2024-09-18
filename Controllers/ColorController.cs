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
                return BadRequest("Dados inválidos.");
            }

            if (string.IsNullOrEmpty(request.ColorName))
            {
                return BadRequest("O nome da cor é obrigatório.");
            }

           
            string responseMessage = $"A cor {request.ColorName} tem intensidade {request.Intensity}.";

            return Ok(responseMessage);
        }
    }
}