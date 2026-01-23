using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AgencyWebApp.Infrastructure.Data;
namespace AgencyWebApp.Infrastructure.Repositories.Implementations
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(AppDbContext context) : base(context) { }
    }

}
