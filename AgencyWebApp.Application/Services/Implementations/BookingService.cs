using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Application.DTOs.BookingDTOs;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;
using AgencyWebApp.Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using AgencyWebApp.Application.Common;


namespace AgencyWebApp.Application.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public BookingService(IBookingRepository bookingRepo, IMapper mapper, IMemoryCache cache)
        {
            _bookingRepo = bookingRepo;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<BookingDto?> GetByIdAsync(int id)
        {
            var booking = await _bookingRepo.GetByIdAsync(id);
            return booking == null ? null : _mapper.Map<BookingDto>(booking);
        }

        public async Task<List<BookingDto>> GetAllAsync()
        {
            if(!_cache.TryGetValue(CacheKeys.BOOKINGS, out List<BookingDto>? cachedBookings))
            {
                var bookings = await _bookingRepo.GetAllAsync();

                cachedBookings = _mapper.Map<List<BookingDto>>(bookings);

                var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromHours(1)) // Данные "протухнут" через 1 час
                .SetSlidingExpiration(TimeSpan.FromMinutes(2))  // Если никто не заходит 2 минуты — кэш удалится раньше
                .SetPriority(CacheItemPriority.High);           // Защищаем от случайного удаления при нехватке RAM
                Console.WriteLine("Cache Miss: Loaded bookings from database and stored in cache.");
                _cache.Set(CacheKeys.BOOKINGS, cachedBookings, cacheOptions);
            }

            Console.WriteLine("Cache Hit: Returned bookings from cache.");
            return cachedBookings!;
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
