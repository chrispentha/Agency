using AgencyAPI.Models;

namespace AgencyAPI.Data
{
    public interface IAgencyRepository
    {
        Appointment BookAppointment(Customer customer, DateTime desiredDate);
        List<Appointment> GetTodaysAppointments();
        List<DateTime> GetOffDays();
    }
}
