using System.ComponentModel.DataAnnotations;

namespace ISOmeterAPI.Data.Models.DeviceDTOs
{
    public class GetDevicesDTO
    {
        public int Id { get; set; }
        public int UniversalId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
    }
}
