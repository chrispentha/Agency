using AgencyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyAPI.Data
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetByDate(DateTime date)
        {
            var appointment = await _context.Appointments.Where(a => a.Date == date).ToListAsync();
            return appointment;
        }

        public async Task Add(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }
    }
}
