using AgencyWebApp.Application.Common;
using AgencyWebApp.Application.DTOs.HotelDTOs;
using AgencyWebApp.Application.DTOs.MapDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;


namespace AgencyWebApp.Application.Services.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1); // Семафор для синхронизации доступа к кэшу

        public HotelService(IHotelRepository hotelRepo, IMapper mapper, IMemoryCache cache)
        {
            _hotelRepo = hotelRepo;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<HotelDto?> GetByIdAsync(int id)
        {
            var hotel = await _hotelRepo.GetByIdAsync(id);
            return hotel == null ? null : _mapper.Map<HotelDto>(hotel);
        }

        public async Task<List<HotelDto>> GetAllAsync()
        {
            // Шаг 1: Быстрая проверка кэша (без блокировки)

            if (!_cache.TryGetValue(CacheKeys.HOTELS, out List<HotelDto>? cachedHotels))
            {
                // Шаг 2: Если кэша нет, ждем своей очереди у "турникета"
                await semaphore.WaitAsync();
                try
                {
                    // Шаг 3: Двойная проверка (Double-Check Locking)
                    // Пока мы ждали в очереди, первый поток мог уже записать данные в кэш!
                    if (!_cache.TryGetValue(CacheKeys.HOTELS, out cachedHotels))
                    {
                        Console.WriteLine("Cache Miss: Первый поток пошел в базу за данными...");
                        var hotels = await _hotelRepo.GetAllAsync();
                        cachedHotels = _mapper.Map<List<HotelDto>>(hotels);
                        var cacheOptions = new MemoryCacheEntryOptions()
                       .SetAbsoluteExpiration(TimeSpan.FromHours(1)) // Данные "протухнут" через 1 час
                       .SetSlidingExpiration(TimeSpan.FromMinutes(2))  // Если никто не заходит 2 минуты — кэш удалится раньше
                       .SetPriority(CacheItemPriority.High);           // Защищаем от случайного удаления при нехватке RAM
                        Console.WriteLine("Cache Miss: Loaded hotels from database and stored in cache.");
                        _cache.Set(CacheKeys.HOTELS, cachedHotels, cacheOptions);
                    }
                    else
                    {
                        Console.WriteLine("Cache Hit: Данные взяты из кэша мгновенно.");
                    }
                }
                finally
                {
                    semaphore.Release();
                }
            }   
            else
            {
                Console.WriteLine("Cache Hit: Returned hotels from cache.");
            }
            return cachedHotels!;
        }

        public async Task<HotelDto> CreateAsync(CreateHotelDto dto)
        {
            var hotel = _mapper.Map<Hotel>(dto);
            var created = await _hotelRepo.CreateAsync(hotel);
            return _mapper.Map<HotelDto>(created);
        }

        public async Task<HotelDto?> UpdateAsync(int id, UpdateHotelDto dto)
        {
            var hotel = await _hotelRepo.GetByIdAsync(id);
            if (hotel == null)
                throw new Exception("Hotel not found");
            if (dto.Status)
            {
                hotel.Status = dto.Status;
            }
            // Строки — защищаемся от Swagger "string" и пустых значений
            if (!string.IsNullOrWhiteSpace(dto.Name))
                hotel.Name = dto.Name;

            if (!string.IsNullOrWhiteSpace(dto.Address))
                hotel.Address = dto.Address;

            if (!string.IsNullOrWhiteSpace(dto.City))
                hotel.City = dto.City;

            if (!string.IsNullOrWhiteSpace(dto.Country))
                hotel.Country = dto.Country;

            if (!string.IsNullOrWhiteSpace(dto.Description))
                hotel.Description = dto.Description;

            // Числовые поля
            if (dto.Latitude.HasValue)
                hotel.Latitude = dto.Latitude.Value;

            if (dto.Longitude.HasValue)
                hotel.Longitude = dto.Longitude.Value;

            await _hotelRepo.SaveChangesAsync();
            return _mapper.Map<HotelDto>(hotel);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _hotelRepo.DeleteAsync(id);
        }
        public async Task<List<HotelMapDto>> GetHotelsForMapAsync()
        {
            var hotels = await _hotelRepo.GetAllAsync();

            return hotels.Select(h => new HotelMapDto
            {
                Id = h.Id,
                Name = h.Name,
                Latitude = (double)h.Latitude,
                Longitude = (double)h.Longitude
            }).ToList();
        }
    }

}
