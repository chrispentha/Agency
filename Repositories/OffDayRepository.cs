using AgencyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyAPI.Repositories
{
    public class OffDayRepository : IOffDayRepository
    {
        private readonly AppDbContext _context;

        public OffDayRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsOffDay(DateTime date)
        {
            var dateResult = await _context.OffDays.AnyAsync(o => o.Date == date);
            return dateResult;
        }

        public async Task<IEnumerable<DateTime>> GetAll()
        {
            var offDays = await _context.OffDays.Select(o => o.Date).ToListAsync();
            return offDays;
        }

        public async Task Add(OffDay offDay)
        {
            await _context.OffDays.AddAsync(offDay);
            await _context.SaveChangesAsync();
        }
    }
}
