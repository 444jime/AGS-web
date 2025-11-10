using AGS_Models;
using AGS_Models.DTO;
using AGS_services.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Proyectos_AGS.Controllers
{
    [Route("AGS/users")]
    [ApiController]

    public class UserController : ControllerBase

    {
        private readonly IUserRepository _UserService;

        public UserController(IUserRepository userService)
        {
            _UserService = userService;
        }

        [HttpGet("GetUsers")]
        [Authorize]
        public async Task<List<User>> GetUsers()
        {
            return await Task.Run(() => _UserService.GetUsers());
        }

        [HttpPost("CreateUser")]
        public async Task<UserResultDTO> CreateUser(User user)
        {
            return await Task.Run(() => _UserService.CreateUser(user));

        }

        [HttpPost("Login")]
        public async Task<UserResultDTO> Login(UserDTO user)
        {
            return await Task.Run(() => _UserService.Login(user));
        }

        [HttpGet("{id}")]
        [Authorize] 
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _UserService.GetUserById(id);
            if (user == null)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        [Authorize] 
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.id)
            {
                return BadRequest(new { message = "Los id no coinciden" });
            }

            var result = await _UserService.UpdateUser(id, user);
            if (!result.Result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpDelete("{id}")]
        [Authorize] 
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _UserService.DeleteUser(id);
            if (!result.Result)
            {
                return NotFound(result); 
            }
            return Ok(result);
        }

        [HttpPost("ChangePass/{id}")]
        [Authorize] 
        public async Task<IActionResult> ChangePass(int id, [FromBody] ChangePassDTO passDto)
        {
            if (passDto.NewPassword != passDto.ConfirmNewPassword)
            {
                return BadRequest(new { Result = false, Message = "Las contraseñas no coinciden" });
            }
            var result = await _UserService.ChangePass(id, passDto);
            if (!result.Result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
