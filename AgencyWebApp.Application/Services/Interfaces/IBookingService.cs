

using AgencyWebApp.Application.DTOs.BookingDTOs;

namespace AgencyWebApp.Application.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingDto?> GetByIdAsync(int id);
        Task<List<BookingDto>> GetAllAsync();
        Task<BookingDto> CreateAsync(CreateBookingDto dto);
        Task<BookingDto?> UpdateAsync(int id, UpdateBookingDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
