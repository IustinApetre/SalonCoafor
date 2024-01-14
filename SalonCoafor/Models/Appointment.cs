using System.ComponentModel.DataAnnotations;

namespace SalonCoafor.Models
{
    public class Appointment
    {
        public int ID { get; set; }
  
        [Display(Name = "Stylist")]
        public int? StylistID { get; set; }
        
        public int? UserID { get; set; }
        
        public int? ServiceID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Programării")]
        public DateTime Data { get; set; }

        public string Ora { get; set; }
        public User? User { get; set; }
        public Stylist? Stylist { get; set; }
        public Service? Service { get; set; }
    }
}
