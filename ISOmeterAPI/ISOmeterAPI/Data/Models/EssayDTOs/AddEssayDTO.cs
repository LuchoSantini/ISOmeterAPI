using ISOmeterAPI.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISOmeterAPI.Data.Models.EssayDTOs
{
    public class AddEssayDTO
    {
        public int DeviceId { get; set; }
        public int RoomId { get; set; }
    }
}
