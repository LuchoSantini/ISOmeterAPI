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

        public bool AddMeasurement(int universalId)
        {
            var existingDevice = _context.Devices
                .FirstOrDefault(p => p.UniversalId == universalId);

            if (existingDevice != null)
            {
                DateTime baseTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0); // Inicia a las 12:00 am

                List<Measurement> measurements = new List<Measurement>
                {
                    new Measurement { Temperature = 16.5m, Humidity = 85.2m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(0) },  // 00:00
                    new Measurement { Temperature = 16.2m, Humidity = 86.0m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(1) },  // 01:00
                    new Measurement { Temperature = 15.8m, Humidity = 87.3m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(2) },  // 02:00
                    new Measurement { Temperature = 15.6m, Humidity = 88.1m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(3) },  // 03:00
                    new Measurement { Temperature = 15.4m, Humidity = 88.7m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(4) },  // 04:00
                    new Measurement { Temperature = 15.3m, Humidity = 89.0m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(5) },  // 05:00
                    new Measurement { Temperature = 16.0m, Humidity = 88.4m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(6) },  // 06:00
                    new Measurement { Temperature = 17.5m, Humidity = 85.0m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(7) },  // 07:00
                    new Measurement { Temperature = 19.0m, Humidity = 80.2m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(8) },  // 08:00
                    new Measurement { Temperature = 21.5m, Humidity = 75.8m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(9) },  // 09:00
                    new Measurement { Temperature = 23.0m, Humidity = 72.5m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(10) }, // 10:00
                    new Measurement { Temperature = 24.8m, Humidity = 70.1m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(11) }, // 11:00
                    new Measurement { Temperature = 26.2m, Humidity = 67.8m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(12) }, // 12:00
                    new Measurement { Temperature = 27.5m, Humidity = 65.5m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(13) }, // 13:00
                    new Measurement { Temperature = 28.3m, Humidity = 63.4m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(14) }, // 14:00
                    new Measurement { Temperature = 28.5m, Humidity = 62.0m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(15) }, // 15:00
                    new Measurement { Temperature = 28.2m, Humidity = 63.5m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(16) }, // 16:00
                    new Measurement { Temperature = 27.0m, Humidity = 65.0m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(17) }, // 17:00
                    new Measurement { Temperature = 25.4m, Humidity = 67.8m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(18) }, // 18:00
                    new Measurement { Temperature = 24.0m, Humidity = 70.2m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(19) }, // 19:00
                    new Measurement { Temperature = 22.5m, Humidity = 72.8m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(20) }, // 20:00
                    new Measurement { Temperature = 21.0m, Humidity = 75.4m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(21) }, // 21:00
                    new Measurement { Temperature = 19.8m, Humidity = 78.5m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(22) }, // 22:00
                    new Measurement { Temperature = 18.5m, Humidity = 81.0m, DeviceId = existingDevice.Id, ChangeDate = DateTime.Today.AddHours(23) }, // 23:00
                };

                _context.Measurements.AddRange(measurements);
                _context.SaveChanges();
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
                    UniversalId = m.Device.UniversalId,
                    Temperature = m.Temperature,
                    Humidity = m.Humidity,
                    ChangeDate = m.ChangeDate,
                    Status = m.Device.Status
                    
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<GetMeasurementsDTO>> GetMeasurementById(int deviceId)
        {
            return await _context.Measurements
                .Where(m => m.DeviceId == deviceId)
                .Select(m => new GetMeasurementsDTO
                {
                    Id = m.Id,
                    Name = m.Device.Name,
                    Model = m.Device.Model,
                    UniversalId = m.Device.UniversalId,
                    Temperature = m.Temperature,
                    Humidity = m.Humidity,
                    ChangeDate = m.ChangeDate,
                    Status = m.Device.Status
                })
                .ToListAsync(); 
        }
    }
}
