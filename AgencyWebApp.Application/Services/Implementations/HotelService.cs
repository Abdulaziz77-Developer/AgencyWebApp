using AgencyWebApp.Application.Common;
using AgencyWebApp.Application.DTOs.HotelDTOs;
using AgencyWebApp.Application.DTOs.MapDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;


namespace AgencyWebApp.Application.Services.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IValidator<CreateHotelDto> _createValidator;
        private readonly IValidator<UpdateHotelDto> _updateValidator;
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1); 

        public HotelService(IHotelRepository hotelRepo, IMapper mapper, IMemoryCache cache, IValidator<UpdateHotelDto> updateValidator, IValidator<CreateHotelDto> createValidator)
        {
            _hotelRepo = hotelRepo;
            _mapper = mapper;
            _cache = cache;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
        }

        public async Task<HotelDto?> GetByIdAsync(int id)
        {
            var hotel = await _hotelRepo.GetByIdAsync(id);
            return hotel == null ? null : _mapper.Map<HotelDto>(hotel);
        }

        public async Task<List<HotelDto>> GetAllAsync()
        {
            
            if (!_cache.TryGetValue(CacheKeys.HOTELS, out List<HotelDto>? cachedHotels))
            {
                
                await semaphore.WaitAsync();
                try
                {
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
            var validationResult = await _createValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                var errorMessage = validationResult.Errors.First().ErrorMessage;
                throw new Exception(errorMessage);
            }

            var hotel = _mapper.Map<Hotel>(dto);

            var created = await _hotelRepo.CreateAsync(hotel);

            return _mapper.Map<HotelDto>(created);
        }

        public async Task<HotelDto?> UpdateAsync(int id, UpdateHotelDto dto)
        {
            // Validate incoming data
            var validationResult = await _updateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                var errorMessage = validationResult.Errors.First().ErrorMessage;
                throw new Exception(errorMessage);
            }

            // Retrieve existing entity
            var hotel = await _hotelRepo.GetByIdAsync(id);
            if (hotel == null)
                throw new Exception("Hotel not found");

            // Apply updates from DTO to the existing entity using AutoMapper
            _mapper.Map(dto, hotel);

            // Persist changes to the database
            await _hotelRepo.SaveChangesAsync();

            // Return the updated data as a DTO
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
