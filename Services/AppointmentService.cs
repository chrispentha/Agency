using AgencyAPI.Data;
using AgencyAPI.Models;
using AgencyAPI.Repositories;

namespace AgencyAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IOffDayRepository _offDayRepository;
        private const int MaxAppointmentsPerDay = 10;

        public AppointmentService(IAppointmentRepository appointmentRepository, IOffDayRepository offDayRepository)
        {
            _appointmentRepository = appointmentRepository;
            _offDayRepository = offDayRepository;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForDay(DateTime date)
        {
            var appointment = await _appointmentRepository.GetByDate(date);
            return appointment;
        }

        public async Task<string> BookAppointment(string customerName)
        {
            var date = DateTime.Today;

            while (true)
            {
                var offDay = await _offDayRepository.IsOffDay(date);

                if (offDay)
                {
                    date = date.AddDays(1);
                    continue;
                }

                var appointments = await _appointmentRepository.GetByDate(date);
                if (appointments.Count() < MaxAppointmentsPerDay)
                {
                    var token = Guid.NewGuid().ToString();
                    var appointment = new Appointment
                    {
                        Date = date,
                        CustomerName = customerName,
                        Token = token
                    };
                    await _appointmentRepository.Add(appointment);
                    return token;
                }

                date = date.AddDays(1);
            }
        }

        public async Task<IEnumerable<DateTime>> GetOffDays()
        {
            var getOffDays = await _offDayRepository.GetAll();
            return getOffDays;
        }

        public async Task AddOffDay(DateTime date)
        {
            var offDay = await _offDayRepository.IsOffDay(date);

            if (!offDay)
                await _offDayRepository.Add(new OffDay { Date = date });
        }
    }
}
