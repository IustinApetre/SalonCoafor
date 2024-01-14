using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalonCoafor.Models
{
    public class Service
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; } // Durata în minute, de exemplu
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]

        public decimal Price { get; set; }
        public ICollection<Appointment>? Programari { get; set; }
    }
}
