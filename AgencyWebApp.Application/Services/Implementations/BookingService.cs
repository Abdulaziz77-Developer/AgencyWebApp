using AgencyWebApp.Application.Common;
using AgencyWebApp.Application.DTOs.BookingDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;


namespace AgencyWebApp.Application.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private readonly IValidator<CreateBookingDto> _createValidator;
        private readonly IValidator<UpdateBookingDto> _updateValidator;

        public BookingService(IBookingRepository bookingRepo, IMapper mapper, IMemoryCache cache,  IValidator<CreateBookingDto> createValidator,
         IValidator<UpdateBookingDto> updateValidator)
        {
            _bookingRepo = bookingRepo;
            _mapper = mapper;
            _cache = cache;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
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
                await semaphore.WaitAsync();
                try
                {
                    if (!_cache.TryGetValue(CacheKeys.BOOKINGS, out cachedBookings))
                    {
                        Console.WriteLine("Cache Miss: Первый поток пошел в базу за данными...");
                        var bookings = await _bookingRepo.GetAllAsync();
                        cachedBookings = _mapper.Map<List<BookingDto>>(bookings);
                        var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromHours(1)) // Данные "протухнут" через 1 час
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2))  // Если никто не заходит 2 минуты — кэш удалится раньше
                        .SetPriority(CacheItemPriority.High);           // Защищаем от случайного удаления при нехватке RAM
                        Console.WriteLine("Cache Miss: Loaded bookings from database and stored in cache.");
                        _cache.Set(CacheKeys.BOOKINGS, cachedBookings, cacheOptions);
                    }
                    else
                    {
                        Console.WriteLine("Cache Hit: data taken from cache instantly.");
                    }
                }
                finally
                {
                    semaphore.Release();
                }
            }
            else
            {
            Console.WriteLine("Cache Hit: Returned bookings from cache.");
            }

            return cachedBookings!;
        }

        public async Task<BookingDto> CreateAsync(CreateBookingDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                var errorMessage = validationResult.Errors.First().ErrorMessage;
                throw new Exception(errorMessage);
            }

            var booking = _mapper.Map<Booking>(dto);

            var created = await _bookingRepo.CreateAsync(booking);

            return _mapper.Map<BookingDto>(created);
        }

        public async Task<BookingDto?> UpdateAsync(int id, UpdateBookingDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.Errors.First().ErrorMessage);
            }

            var booking = await _bookingRepo.GetByIdAsync(id);
            if (booking == null)
                throw new Exception("Booking not found");

            _mapper.Map(dto, booking);

            await _bookingRepo.SaveChangesAsync();

            return _mapper.Map<BookingDto>(booking);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookingRepo.DeleteAsync(id);
        }
    }

}
