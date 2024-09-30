using ISOmeterAPI.Data.Entities;

namespace ISOmeterAPI.Data.Models.DeviceDTOs
{
    public class AddDeviceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int UserId { get; set; }
    }
}
