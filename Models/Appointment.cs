using System.ComponentModel.DataAnnotations;

namespace AgencyAPI.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int Token { get; set; } // Consider using a separate Token model for more complex token management

        public int CustomerId { get; set; }

        public Customer Customer { get; set; } = new Customer();
    }
}
