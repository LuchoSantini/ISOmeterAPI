namespace ISOmeterAPI.Data.Models.MeasurementDTOs
{
    public class GetMeasurementByIdDTO
    {
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
