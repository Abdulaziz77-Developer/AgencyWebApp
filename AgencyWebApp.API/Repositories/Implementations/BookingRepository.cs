using AgencyWebApp.API.Data;
using AgencyWebApp.API.DTOs.BookingDTOs;
using AgencyWebApp.API.Models;
using AgencyWebApp.API.Repositories.Interfaces;

namespace AgencyWebApp.API.Repositories.Implementations
{
    public class BookingRepository : BaseRepository<Booking, UpdateBookingDto>, IBookingRepository
    {
        public BookingRepository(AppDbContext context) : base(context) { }
    }

}
