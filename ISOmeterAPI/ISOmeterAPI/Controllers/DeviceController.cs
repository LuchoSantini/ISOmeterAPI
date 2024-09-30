using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.DeviceDTOs;
using ISOmeterAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISOmeterAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DeviceController : Controller
    {
        private readonly IDeviceService _deviceService;
        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet("devices")]
        public async Task<ActionResult<IEnumerable<Device>>> GetAllDevices()
        {
            try
            {
                return Ok(await _deviceService.GetAllDevices());
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("device/{id}")]
        public async Task<ActionResult<Device>> GetDeviceById(int id)
        {
            try
            {
                return Ok(await _deviceService.GetDeviceById(id));
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("device")]
        public IActionResult AddDevice([FromBody] AddDeviceDTO addDeviceDTO)
        {
            try
            {
                if (_deviceService.AddDevice(addDeviceDTO))
                {
                    return Ok("Dispositivo agregado");
                }
                return BadRequest("Error al agregar el dispositivo.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("device/edit/{id}")]
        public IActionResult EditDevice(int id, EditDeviceDTO editDeviceDTO)
        {
            try
            {
                if (_deviceService.EditDevice(id, editDeviceDTO))
                {
                    return Ok("Dispositivo editado");
                }
                return BadRequest("Error al editar el dispositivo.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("device/status/{id}")]
        public IActionResult ChangeDeviceStatus(int id, StatusDeviceDTO statusDeviceDTO)
        {
            _deviceService.ChangeDeviceStatus(id, statusDeviceDTO);

            return Ok($"Se cambió el estado a {statusDeviceDTO.Status}");
        }
    }
}
