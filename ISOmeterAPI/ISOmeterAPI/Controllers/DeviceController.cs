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

        [HttpPut("device/edit/{universalId}")]
        public IActionResult EditDevice(int universalId, EditDeviceDTO editDeviceDTO)
        {
            try
            {
                if (_deviceService.EditDevice(universalId, editDeviceDTO))
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

        [HttpGet("device/status/{universalId}")]
        public IActionResult ChangeDeviceStatus(int universalId)
        {
            try
            {
                var deviceStatus = _deviceService.ChangeDeviceStatus(universalId);

                if (deviceStatus != null)
                {
                    return Ok(new { Status = deviceStatus });
                }
                return BadRequest("Error al obtener el estado del dispositivo.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
