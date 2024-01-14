using System.ComponentModel.DataAnnotations;

namespace SalonCoafor.Models
{
    public class Stylist
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<Appointment>? Appointments { get; set; } //navigation property
    }
}
