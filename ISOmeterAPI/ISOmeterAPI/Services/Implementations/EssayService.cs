using ISOmeterAPI.Context;
using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.EssayDTOs;
using ISOmeterAPI.Data.Models.MeasurementDTOs;
using ISOmeterAPI.Data.Models.RoomDTO;
using ISOmeterAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ISOmeterAPI.Services.Implementations
{
    public class EssayService : IEssayService
    {
        private readonly ISOmeterContext _context;
        private readonly IMeasurementService _measurementService;

        public EssayService(ISOmeterContext context, IMeasurementService measurementService)
        {
            _context = context;
            _measurementService = measurementService;
        }

        public async Task<bool> AddEssayAsync(int universalId)
        {
            var existingDevice = _context.Devices
                .FirstOrDefault(d => d.UniversalId == universalId);

            if (existingDevice != null)
            {
                Essay newEssay = new Essay
                {
                    InitDate = DateTime.Now,
                    DeviceId = existingDevice.Id,
                    RoomId = existingDevice.RoomId,
                };

                _context.Essays.Add(newEssay);

                await _context.SaveChangesAsync();
                await _measurementService.AddMeasurementAsync(newEssay.Id);

                newEssay.EndDate = DateTime.Now;
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<IEnumerable<GetEssayDTO>> GetEssayById(int deviceId, int roomId)
        {
            return await _context.Essays
                .Where(m => m.DeviceId == deviceId)
                .Where(m => m.RoomId == roomId)
                .Select(m => new GetEssayDTO
                {
                    Id = m.Id,
                    Name = m.Device.Name,
                    UniversalId = m.Device.UniversalId,
                    InitDate = m.InitDate,
                    EndDate = m.EndDate,
                    RoomId = m.RoomId,
                    Measurements = m.Measurements
                        .Select(m => new GetMeasurementByIdDTO
                        {
                            Temperature = m.Temperature,
                            Humidity = m.Humidity,
                            ChangeDate = m.ChangeDate
                        })
                        .ToList()
                })
                .ToListAsync();
        }
    }
}
