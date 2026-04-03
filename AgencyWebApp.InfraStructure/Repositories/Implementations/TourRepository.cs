using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AgencyWebApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AgencyWebApp.Infrastructure.Repositories.Implementations
{
    public class TourRepository : BaseRepository<Tour>, ITourRepository
    {
        public TourRepository(AppDbContext context) : base(context) { }

        public async Task<List<Tour>> GetToursWithPointsAsync()
        {
            return await _context.Tours.Include(t => t.TourPoints).ToListAsync();
        }
    }

}
