using AgencyAPI.Models;

namespace AgencyAPI.Data
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly AgencyContext _context;
        private readonly int _maxAppointmentsPerDay;
        private readonly List<DateTime> _offDays;

        public AgencyRepository(AgencyContext context, int maxAppointmentsPerDay, IEnumerable<DateTime> offDays)
        {
            _context = context;
            _maxAppointmentsPerDay = maxAppointmentsPerDay;
            _offDays = offDays.ToList();
        }

        public Appointment BookAppointment(Customer customer, DateTime desiredDate)
        {
            if (_offDays.Contains(desiredDate))
            {
                throw new Exception("Appointments are not available on off days.");
            }

            var existingAppointments = _context.Appointments.Where(a => a.Date == desiredDate);
            if (existingAppointments.Count() >= _maxAppointmentsPerDay)
            {
                throw new Exception("Maximum appointments reached for this day. Please try booking for a different date.");
            }

            var appointment = new Appointment
            {
                Date = desiredDate,
                Token = existingAppointments.Count() + 1,
                Customer = customer
            };

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return appointment;
        }

        public List<Appointment> GetTodaysAppointments()
        {
            return _context.Appointments.Where(a => a.Date == DateTime.Today).ToList();
        }

        public List<DateTime> GetOffDays()
        {
            return _offDays;
        }
    }
}
