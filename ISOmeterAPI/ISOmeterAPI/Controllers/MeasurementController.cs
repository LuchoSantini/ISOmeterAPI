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

        [HttpPost("measurements/{essayId}")]
        public async Task<IActionResult> AddMeasurements(int essayId)
        {
            try
            {
                var result = await _measurementService.AddMeasurementAsync(essayId);

                if (result)
                {
                    return Ok("Medición agregada");
                }
                return BadRequest("Error al agregar la medición.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("measurements")]
        public async Task<ActionResult<IEnumerable<Device>>> GetAllMeasurements()
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

        //[HttpGet("measurement/{deviceId}")]
        //public async Task<ActionResult<Device>> GetMeasurementById(int deviceId)
        //{
        //    try
        //    {
        //        return Ok(await _measurementService.GetMeasurementById(deviceId));
        //    }
        //    catch (ArgumentException ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
