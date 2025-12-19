using AgencyWebApp.API.Data;
using AgencyWebApp.API.DTOs.HotelDTOs;
using AgencyWebApp.API.Models;
using AgencyWebApp.API.Repositories.Interfaces;

namespace AgencyWebApp.API.Repositories.Implementations
{
    public class HotelRepository : BaseRepository<Hotel, UpdateHotelDto>, IHotelRepository
    {
        public HotelRepository(AppDbContext context) : base(context) { }
    }

}
