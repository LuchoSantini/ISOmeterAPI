using ISOmeterAPI.Context;
using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.DeviceDTOs;
using ISOmeterAPI.Data.Models.MeasurementDTOs;
using ISOmeterAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ISOmeterAPI.Services.Implementations
{
    public class MeasurementService : IMeasurementService
    {
        private readonly ISOmeterContext _context;
        public MeasurementService(ISOmeterContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMeasurementAsync(int essayId)
        {
            var existingEssay = _context.Essays
                .FirstOrDefault(e => e.Id == essayId);

            if (existingEssay != null)
            {
                DateTime baseTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0); // Inicia a las 12:00 am

                decimal temperature = 10.0m;
                decimal humidity = 75.2m;

                for (int i = 0; i < 24; i++) // Iteraciones
                {
                    // Crear la medición
                    var measurement = new Measurement
                    {
                        Temperature = temperature,
                        Humidity = humidity,
                        EssayId = existingEssay.Id,
                        ChangeDate = baseTime.AddHours(i + 1) // Incremento
                    };

                    _context.Measurements.Add(measurement);
                    await _context.SaveChangesAsync();

                    // Cambiar los valores para la próxima iteración
                    temperature += 0.5m;
                    humidity -= 0.7m;

                    // Delay en ms 5000 = 5segs
                    await Task.Delay(0);
                }

                return true;
            }
            return false;
        }


        public async Task<IEnumerable<GetMeasurementsDTO>> GetAllMeasurements()
        {
            return await _context.Measurements
                .Select(m => new GetMeasurementsDTO
                {
                    Id = m.Id,
                    EssayId = m.EssayId, 
                    Temperature = m.Temperature,
                    Humidity = m.Humidity,
                    ChangeDate = m.ChangeDate,                    
                })
                .ToListAsync();
        }

        //public async Task<IEnumerable<GetMeasurementsDTO>> GetMeasurementById(int deviceId)
        //{
        //    return await _context.Measurements
        //        .Where(m => m.DeviceId == deviceId)
        //        .Select(m => new GetMeasurementsDTO
        //        {
        //            Id = m.Id,
        //            Name = m.Device.Name,
        //            Model = m.Device.Model,
        //            UniversalId = m.Device.UniversalId,
        //            Temperature = m.Temperature,
        //            Humidity = m.Humidity,
        //            ChangeDate = m.ChangeDate,
        //            Status = m.Device.Status
        //        })
        //        .ToListAsync(); 
        //}
    }
}
