using System.ComponentModel.DataAnnotations;

namespace AgencyAPI.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty; // Optional

        public string Email { get; set; } = string.Empty; // Optional

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
