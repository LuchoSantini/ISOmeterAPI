using System.ComponentModel.DataAnnotations.Schema;

namespace ISOmeterAPI.Data.Entities
{
    public class DeviceHistory
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public Device Device { get; set; }
        public bool Status { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
