using AgencyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyAPI
{
    public class AgencyContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Agency;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
