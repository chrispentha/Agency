using AgencyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyAPI
{
    public class AppDbContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<OffDay> OffDays { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
