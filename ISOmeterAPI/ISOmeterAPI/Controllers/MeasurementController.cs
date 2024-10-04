using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.DeviceDTOs;
using ISOmeterAPI.Services.Implementations;
using ISOmeterAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISOmeterAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MeasurementController : Controller
    {
        private readonly IMeasurementService _measurementService;
        public MeasurementController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }

        [HttpPost("measurements/{universalId}")]
        public IActionResult AddMeasurements(int universalId)
        {
            try
            {
                if (_measurementService.AddMeasurement(universalId))
                {
                    return Ok("Medicion agregada");
                }
                return BadRequest("Error al agregar la Medicion.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("measurements")]
        public async Task<ActionResult<IEnumerable<Device>>> GetAllDevices()
        {
            try
            {
                return Ok(await _measurementService.GetAllMeasurements());
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("measurement/{deviceId}")]
        public async Task<ActionResult<Device>> GetMeasurementById(int deviceId)
        {
            try
            {
                return Ok(await _measurementService.GetMeasurementById(deviceId));
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
