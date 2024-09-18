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

        [HttpPost] 
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");
            }

           
            bool emailExists = await _userService.EmailExistsAsync(user.Email);
            if (emailExists)
            {
                return Conflict("Email already exists");
            }

            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpGet] 
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] User updatedUser)
        {
            if (updatedUser == null)
            {
                return BadRequest("User cannot be null");
            }

           
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound("User not found");
            }

           
            if (existingUser.Email != updatedUser.Email)
            {
                bool emailExists = await _userService.EmailExistsAsync(updatedUser.Email);
                if (emailExists)
                {
                    return Conflict("Email already exists");
                }
            }

           
            updatedUser.Id = id;
            await _userService.UpdateUserAsync(id, updatedUser);

            return NoContent(); 
        }


    }
}