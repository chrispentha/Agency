using AgencyAPI.Models;

namespace AgencyAPI.Repositories
{
    public interface IOffDayRepository
    {
        Task<bool> IsOffDay(DateTime date);
        Task<IEnumerable<DateTime>> GetAll();
        Task Add(OffDay offDay);
    }
}
