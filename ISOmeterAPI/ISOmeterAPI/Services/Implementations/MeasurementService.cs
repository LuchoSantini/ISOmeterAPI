using ISOmeterAPI.Context;
using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.DeviceDTOs;
using ISOmeterAPI.Data.Models.MeasurementDTOs;
using ISOmeterAPI.Services.Interfaces;

namespace ISOmeterAPI.Services.Implementations
{
    public class MeasurementService : IMeasurementService
    {
        private readonly ISOmeterContext _context;
        public MeasurementService(ISOmeterContext context)
        {
            _context = context;
        }

        public bool AddMeasurement(int deviceId)
        {
            var existingDevice = _context.Devices
                .FirstOrDefault(p => p.Id == deviceId);

            if (existingDevice != null)
            {
                List<Measurement> measurements = new List<Measurement>
                {
                    new Measurement { Temperature = 23.5m, Humidity = 60.2m, DeviceId = deviceId, ChangeDate = DateTime.Now.AddSeconds(-DateTime.Now.Second) },
                    new Measurement { Temperature = 22.1m, Humidity = 58.3m, DeviceId = deviceId, ChangeDate = DateTime.Now.AddMinutes(-10).AddSeconds(-DateTime.Now.Second) },
                    new Measurement { Temperature = 21.8m, Humidity = 57.0m, DeviceId = deviceId, ChangeDate = DateTime.Now.AddMinutes(-20).AddSeconds(-DateTime.Now.Second) },
                    new Measurement { Temperature = 24.3m, Humidity = 62.1m, DeviceId = deviceId, ChangeDate = DateTime.Now.AddMinutes(-30).AddSeconds(-DateTime.Now.Second) },
                    new Measurement { Temperature = 25.0m, Humidity = 64.5m, DeviceId = deviceId, ChangeDate = DateTime.Now.AddMinutes(-40).AddSeconds(-DateTime.Now.Second) },
                    new Measurement { Temperature = 23.9m, Humidity = 60.0m, DeviceId = deviceId, ChangeDate = DateTime.Now.AddMinutes(-50).AddSeconds(-DateTime.Now.Second) },
                    new Measurement { Temperature = 22.7m, Humidity = 59.2m, DeviceId = deviceId, ChangeDate = DateTime.Now.AddMinutes(-60).AddSeconds(-DateTime.Now.Second) },
                    new Measurement { Temperature = 21.5m, Humidity = 57.8m, DeviceId = deviceId, ChangeDate = DateTime.Now.AddMinutes(-70).AddSeconds(-DateTime.Now.Second) },
                    new Measurement { Temperature = 20.3m, Humidity = 55.6m, DeviceId = deviceId, ChangeDate = DateTime.Now.AddMinutes(-80).AddSeconds(-DateTime.Now.Second) },
                    new Measurement { Temperature = 19.8m, Humidity = 54.0m, DeviceId = deviceId, ChangeDate = DateTime.Now.AddMinutes(-90).AddSeconds(-DateTime.Now.Second) }
                };

                _context.Measurements.AddRange(measurements);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
