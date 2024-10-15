using System.ComponentModel.DataAnnotations.Schema;

namespace ISOmeterAPI.Data.Models.RoomDTO
{
    public class AddRoomDTO
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
