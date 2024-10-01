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

        [HttpPost("mesurements")]
        public IActionResult AddMeasurements(int deviceId)
        {
            try
            {
                if (_measurementService.AddMeasurement(deviceId))
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
    }
}
