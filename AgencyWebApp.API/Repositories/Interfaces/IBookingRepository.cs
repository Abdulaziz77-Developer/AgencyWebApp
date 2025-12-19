using AgencyWebApp.API.DTOs.BookingDTOs;
using AgencyWebApp.API.Models;

namespace AgencyWebApp.API.Repositories.Interfaces
{
    public interface IBookingRepository : IBaseRepository<Booking, UpdateBookingDto>
    {
    }
}
