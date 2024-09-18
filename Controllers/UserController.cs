using Microsoft.AspNetCore.Mvc;
using email_api.Models;
using email_api.Services;

namespace email_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost] // aqui ele cria minha tabela
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");
            }

            // Verifica se o e-mail j� existe
            bool emailExists = await _userService.EmailExistsAsync(user.Email);
            if (emailExists)
            {
                return Conflict("Email already exists");
            }

            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpGet] // aqui eu busco a minha tabela
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        //aqui ele realiza um put (altera��o do usuario)
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] User updatedUser)
        {
            if (updatedUser == null)
            {
                return BadRequest("User cannot be null");
            }

            // Verifica se o ID � v�lido
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            // Verifica se o e-mail est� sendo atualizado e se j� existe
            if (existingUser.Email != updatedUser.Email)
            {
                bool emailExists = await _userService.EmailExistsAsync(updatedUser.Email);
                if (emailExists)
                {
                    return Conflict("Email already exists");
                }
            }

            // Atualiza o usu�rio
            updatedUser.Id = id; // Garante que o ID n�o seja alterado
            await _userService.UpdateUserAsync(id, updatedUser);

            return NoContent(); // Retorna 204 No Content se a atualiza��o for bem-sucedida
        }


    }
}