using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISOmeterAPI.Data.Entities
{
    public class Measurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
