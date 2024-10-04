using ISOmeterAPI.Data.Entities;

namespace ISOmeterAPI.Data.Models.MeasurementDTOs
{
    public class GetMeasurementsDTO
    {
        public int Id { get; set; }
        public int UniversalId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public DateTime ChangeDate { get; set; }
        public bool Status { get; set; }
    }
}
