using ISOmeterAPI.Data.Entities;

namespace ISOmeterAPI.Data.Models.MeasurementDTOs
{
    public class AddMeasurementDTO
    {
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public int DeviceId { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
