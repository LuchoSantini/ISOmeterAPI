using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.ExportDBDTOs;
using ISOmeterAPI.Services.Implementations;
using ISOmeterAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISOmeterAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ExportDBController : Controller
    {
        private readonly IExportDBService _exportDBService;
        public ExportDBController(IExportDBService exportDBService)
        {
            _exportDBService = exportDBService;
        }

        [HttpPost("database")]
        public IActionResult ExportDatabaseToExcel([FromBody] PathDTO pathDTO)
        {
            if (pathDTO == null)
            {
                return BadRequest("Ingresa una ruta válida.");
            }

            try
            {
                _exportDBService.ExportDatabaseToExcel(pathDTO.OutputPath);

                return Ok("Base de datos exportada exitosamente a Excel.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al exportar la base de datos a Excel: {ex.Message}");
            }
        }

        [HttpGet("database")]
        public ActionResult<List<string>> GetTableNames()
        {
            try
            {
                var tableNames = _exportDBService.GetTableNames();
                return Ok(tableNames);
            }
            catch (Exception ex)
            {
                // Manejo de errores: devolver un estado 500 con el mensaje de error
                return StatusCode(500, $"Error al obtener los nombres de las tablas: {ex.Message}");
            }
        }
    }
}
