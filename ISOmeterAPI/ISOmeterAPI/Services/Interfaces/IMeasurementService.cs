using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.MeasurementDTOs;

namespace ISOmeterAPI.Services.Interfaces
{
    public interface IMeasurementService
    {
        public bool AddMeasurement(int universalId);
        public Task<IEnumerable<GetMeasurementsDTO>> GetAllMeasurements();
        public Task<IEnumerable<GetMeasurementsDTO>> GetMeasurementById(int deviceId);

    }
}
