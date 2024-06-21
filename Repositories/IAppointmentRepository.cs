using AgencyAPI.Models;

namespace AgencyAPI.Data
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetByDate(DateTime date);
        Task Add(Appointment appointment);
    }
}
