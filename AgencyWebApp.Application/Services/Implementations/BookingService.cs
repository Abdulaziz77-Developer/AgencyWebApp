using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Application.DTOs.BookingDTOs;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;
using AgencyWebApp.Domain.Models;


namespace AgencyWebApp.Application.Services.Implementations
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
            var booking = await _bookingRepo.GetByIdAsync(id);
            if (booking == null)
                throw new Exception("Booking not found");

            if (dto.TourId.HasValue)
                booking.TourId = dto.TourId.Value;

            if (dto.HotelId.HasValue)
                booking.HotelId = dto.HotelId.Value;

            if (dto.FlightId.HasValue)
                booking.FlightId = dto.FlightId.Value;
            if(dto.Status)
            {
                booking.Status = dto.Status;
            }
            await _bookingRepo.SaveChangesAsync();
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookingRepo.DeleteAsync(id);
        }
    }

}
