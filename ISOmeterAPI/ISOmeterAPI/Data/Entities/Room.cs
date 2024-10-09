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
        public string Description { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public bool Status { get; set; } // Baja lógica
        public ICollection<Device> Devices { get; set; } = new List<Device>();
        public ICollection<Essay> Essays { get; set; } = new List<Essay>();
    }
}
