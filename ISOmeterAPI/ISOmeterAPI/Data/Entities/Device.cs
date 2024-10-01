using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ISOmeterAPI.Data.Entities
{
    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int UniversalId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; } // Podria ser donde está ubicado el device
        public int UserId { get; set; }
        public ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();
        public bool Status { get; set; } // Baja lógica
    }
}
