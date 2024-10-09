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
        [ForeignKey("EssayId")]
        public int EssayId { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
