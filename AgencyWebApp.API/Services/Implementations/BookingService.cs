using AgencyWebApp.API.DTOs.BookingDTOs;
using AgencyWebApp.API.Models;
using AgencyWebApp.API.Repositories.Interfaces;
using AgencyWebApp.API.Services.Interfaces;
using AutoMapper;

namespace AgencyWebApp.API.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepo, IMapper mapper)
        {
            _bookingRepo = bookingRepo;
            _mapper = mapper;
        }

        public async Task<BookingDto?> GetByIdAsync(int id)
        {
            var booking = await _bookingRepo.GetByIdAsync(id);
            return booking == null ? null : _mapper.Map<BookingDto>(booking);
        }

        public async Task<List<BookingDto>> GetAllAsync()
        {
            var bookings = await _bookingRepo.GetAllAsync();
            return _mapper.Map<List<BookingDto>>(bookings);
        }

        public async Task<BookingDto> CreateAsync(CreateBookingDto dto)
        {
            var booking = _mapper.Map<Booking>(dto);
            var created = await _bookingRepo.CreateAsync(booking);
            return _mapper.Map<BookingDto>(created);
        }

        public async Task<BookingDto?> UpdateAsync(int id, UpdateBookingDto dto)
        {
            var updated = await _bookingRepo.UpdateAsync(id, dto);
            return updated == null ? null : _mapper.Map<BookingDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookingRepo.DeleteAsync(id);
        }
    }

}
