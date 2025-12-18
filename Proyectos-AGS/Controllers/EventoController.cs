using AGS_Models;
using AGS_Models.DTO;
using AGS_services.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Proyectos_AGS.Controllers
{
    [Route("AGS/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _service;

        public EventoController(IEventoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene la lista de todos los eventos.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllEventos()
        {
            var eventos = await _service.GetAllEventos();
            return Ok(eventos);
        }

        /// <summary>
        /// Obtiene la lista de todos los eventos segun usuario.
        /// </summary>
        [Authorize]
        [HttpGet("mis-eventos")]
        public async Task<ActionResult<IEnumerable<Evento>>> GetMisEventos()
        {
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(usuarioId))
            {
                return Unauthorized("Usuario no identificado.");
            }

            Console.WriteLine($"DEBUG: El usuario del token es: {usuarioId}");

            var eventos = await _service.GetEventosByUsuario(usuarioId);
            return Ok(eventos);
        }

        /// <summary>
        /// Crea un nuevo evento segun usuario.
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateEvento([FromBody] EventoCreateDTO dto)
        {
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (usuarioId == null) return Unauthorized();
            var nuevo = await _service.CreateEvento(dto, usuarioId);
            return Ok(nuevo);
        }

        /// <summary>
        /// Actualiza un evento 
        /// </summary>
        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateEvento(int id, [FromBody] EventoUpdateDTO dto)
        {
            var res = await _service.UpdateEvento(id, dto);

            if (!res.Result)return BadRequest(res);
            return Ok(res);
        }

        /// <summary>
        /// Elimina un evento.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var res = await _service.DeleteEvento(id);

            if (!res.Result) return NotFound(res);
            return Ok(res);
        }
    }
}