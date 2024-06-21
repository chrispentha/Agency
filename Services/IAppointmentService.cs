using AgencyAPI.Models;

namespace AgencyAPI.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAppointmentsForDay(DateTime date);
        Task<string> BookAppointment(string customerName);
        Task<IEnumerable<DateTime>> GetOffDays();
        Task AddOffDay(DateTime date);
    }
}
