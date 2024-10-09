using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.DeviceDTOs;
using ISOmeterAPI.Services.Implementations;
using ISOmeterAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISOmeterAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EssayController : Controller
    {
        private readonly IEssayService _essayService;
        public EssayController(IEssayService essayService)
        {
            _essayService = essayService;
        }

        // Simula n cantidad de mediciones.
        // Se pueden editar la cantidad y los ms en el essayService
        // IMPORTANTE: Se toma la RoomId del Device, no es necesario pasarla por query
        // De manera que si se edita el Device y se cambia el RoomId, ya está

        [HttpPost("essay/{universalId}")]
        public async Task<IActionResult> AddEssayAsync(int universalId)
        {
            try
            {
                var result = await _essayService.AddEssayAsync(universalId);

                if (result)
                {
                    return Ok("Ensayo agregado");
                }
                return BadRequest("Error al agregar el Ensayo.");
                
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("essay/{deviceId}/{roomId}")]
        public async Task<ActionResult<Essay>> GetEssayById(int deviceId, int roomId)
        {
            try
            {
                return Ok(await _essayService.GetEssayById(deviceId, roomId));
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
