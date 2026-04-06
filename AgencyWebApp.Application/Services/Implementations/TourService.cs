using AgencyWebApp.Application.Common;
using AgencyWebApp.Application.DTOs.MapDTOs;
using AgencyWebApp.Application.DTOs.TourDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;


namespace AgencyWebApp.Application.Services.Implementations
{
    public class TourService : ITourService
    {
        private readonly IMemoryCache _cache;
        private readonly ITourRepository _tourRepo;
        private readonly IMapper _mapper;
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private readonly IValidator<CreateTourDto> _createValidator;
        private readonly IValidator<UpdateTourDto> _updateValidator;


        public TourService(ITourRepository tourRepo, IMapper mapper, IMemoryCache cache, IValidator<UpdateTourDto> updateValidator, IValidator<CreateTourDto> createValidator)
        {
            _tourRepo = tourRepo;
            _mapper = mapper;
            _cache = cache;
            _updateValidator = updateValidator;
            _createValidator = createValidator;

        }

        public async Task<TourDto?> GetByIdAsync(int id)
        {
            
            var tour = await _tourRepo.GetByIdAsync(id);
            return tour == null ? null : _mapper.Map<TourDto>(tour);
        }

        public async Task<List<TourDto>> GetAllAsync()
        {
            // 1. Пытаемся получить данные из оперативной памяти
            if (!_cache.TryGetValue(CacheKeys.TOURS, out List<TourDto>? cachedTours))
            {
                try
                {
                    // 2.1 Если данных нет, ждем своей очереди у "турникета"
                    await semaphore.WaitAsync();
                    // 2.2 Двойная проверка (Double-Check Locking)
                    // Пока мы ждали в очереди, первый поток мог уже записать данные в кэш!
                    if (!_cache.TryGetValue(CacheKeys.TOURS, out cachedTours))
                    {
                        Console.WriteLine("Cache Miss: Первый поток пошел в базу за данными...");
                        // 2. Если в кэше ПУСТО (Cache Miss), идем в базу данных
                         var tours = await _tourRepo.GetAllAsync();
                        // Маппим сущности в DTO
                        cachedTours = _mapper.Map<List<TourDto>>(tours);
                        // 3. Настраиваем политику кэширования
                        var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromHours(1)) // Данные "протухнут" через 1 час
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2))  // Если никто не заходит 2 минуты — кэш удалится раньше
                        .SetPriority(CacheItemPriority.High);           // Защищаем от случайного удаления при нехватке RAM
                        Console.WriteLine("Cache Miss: Loaded tours from database and stored in cache.");
                        // 4. Сохраняем результат в кэш
                        _cache.Set(CacheKeys.TOURS, cachedTours, cacheOptions);
                    }
                }
                finally
                {
                    semaphore.Release();
                }
            }
            else
            {
                Console.WriteLine("Cache Hit: Returned tours from cache.");
            }
            
            return cachedTours!;
        }

        public async Task<TourDto> CreateAsync(CreateTourDto dto)
        {
            // 1. Validate the incoming tour data
            var validationResult = await _createValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                // Extract the error message from the CreateTourDtoValidator
                var errorMessage = validationResult.Errors.First().ErrorMessage;
                throw new Exception(errorMessage);
            }

            // 2. Map the DTO to the Tour domain model
            var tour = _mapper.Map<Tour>(dto);

            // 3. Save the new tour to the database via repository
            var created = await _tourRepo.CreateAsync(tour);

            // 4. Return the result mapped back to a TourDto
            return _mapper.Map<TourDto>(created);
        }

        public async Task<TourDto?> UpdateAsync(int id, UpdateTourDto dto)
        {
            // Validate the incoming update request
            var validationResult = await _updateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                // Extract the error message defined in UpdateTourDtoValidator
                var errorMessage = validationResult.Errors.First().ErrorMessage;
                throw new Exception(errorMessage);
            }

            // Retrieve existing tour from the database
            var tour = await _tourRepo.GetByIdAsync(id);
            if (tour == null)
                throw new Exception("Tour not found");

            // Apply updates from DTO to the existing entity using AutoMapper
            // This replaces all manual "if (dto.Field.HasValue)" checks
            _mapper.Map(dto, tour);

            // Save changes to the database
            await _tourRepo.SaveChangesAsync();

            // Return the updated result as a DTO
            return _mapper.Map<TourDto>(tour);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _tourRepo.DeleteAsync(id);
        }
        public async Task<List<TourMapDto>> GetToursForMapAsync()
        {
            var tours = await _tourRepo.GetAllAsync();

            return tours.Select(t => new TourMapDto
            {
                Id = t.Id,
                Title = t.Title,
                StartLatitude = (double)t.StartLatitude,
                StartLongitude = (double)t.StartLongitude
            }).ToList();
        }

    }

}
