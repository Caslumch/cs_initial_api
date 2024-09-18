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
            // Adicione condições com base nos dados recebidos
            if (request == null)
            {
                return BadRequest("Dados inválidos.");
            }

            if (string.IsNullOrEmpty(request.ColorName))
            {
                return BadRequest("O nome da cor é obrigatório.");
            }

            // Processar os dados
            string responseMessage = $"A cor {request.ColorName} tem intensidade {request.Intensity}.";

            return Ok(responseMessage);
        }
    }
}