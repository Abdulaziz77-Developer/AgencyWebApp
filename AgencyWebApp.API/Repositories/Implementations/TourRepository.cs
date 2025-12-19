using AgencyWebApp.API.Data;
using AgencyWebApp.API.DTOs.TourDTOs;
using AgencyWebApp.API.Models;
using AgencyWebApp.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgencyWebApp.API.Repositories.Implementations
{
    public class TourRepository : BaseRepository<Tour, UpdateTourDto>, ITourRepository
    {
        public TourRepository(AppDbContext context) : base(context) { }

        public async Task<List<Tour>> GetToursWithPointsAsync()
        {
            return await _context.Tours.Include(t => t.TourPoints).ToListAsync();
        }

        
    }

}
