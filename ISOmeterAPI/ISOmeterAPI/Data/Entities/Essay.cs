using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ISOmeterAPI.Data.Entities
{
    public class Essay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? InitDate { get; set; }
        public string? EndDate { get; set; }
        [ForeignKey("DeviceId")]
        public int DeviceId { get; set; }
        public Device Device { get; set; }

        [ForeignKey("RoomId")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();
    }
}
