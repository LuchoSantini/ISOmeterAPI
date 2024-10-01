namespace ISOmeterAPI.Data.Models.DeviceDTOs
{
    public class EditDeviceDTO
    {
        public int UniversalId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }

        //public int? RoomId { get; set; }
        //public bool Status { get; set; }
    }
}
