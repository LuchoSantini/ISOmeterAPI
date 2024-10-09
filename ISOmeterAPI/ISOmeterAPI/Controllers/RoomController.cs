using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.DeviceDTOs;
using ISOmeterAPI.Data.Models.RoomDTO;
using ISOmeterAPI.Services.Implementations;
using ISOmeterAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISOmeterAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost("room")]
        public IActionResult AddRoom([FromBody] AddRoomDTO addRoomDTO)
        {
            try
            {
                if (_roomService.AddRoom(addRoomDTO))
                {
                    return Ok("Habitación agregada");
                }
                return BadRequest("Error al agregar la habitación.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("rooms")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRooms()
        {
            try
            {
                return Ok(await _roomService.GetAllRooms());
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
