using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ISOmeterAPI.Data.Entities
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Observations { get; set; } = string.Empty;
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Device Device { get; set; }
        public bool Status { get; set; } // Baja lógica
    }
}
