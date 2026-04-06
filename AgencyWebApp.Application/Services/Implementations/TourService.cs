using AgencyWebApp.Application.Common;
using AgencyWebApp.Application.DTOs.MapDTOs;
using AgencyWebApp.Application.DTOs.TourDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;


namespace AgencyWebApp.Application.Services.Implementations
{
    public class TourService : ITourService
    {
        private readonly IMemoryCache _cache;
        private readonly ITourRepository _tourRepo;
        private readonly IMapper _mapper;
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1); // Семафор для синхронизации доступа к кэшу
    

        public TourService(ITourRepository tourRepo, IMapper mapper, IMemoryCache cache )
        {
            _tourRepo = tourRepo;
            _mapper = mapper;
            _cache = cache;
            
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

            // 5. Возвращаем либо данные из кэша, либо свежезагруженные
            
            return cachedTours!;
        }

        public async Task<TourDto> CreateAsync(CreateTourDto dto)
        {
            var tour = _mapper.Map<Tour>(dto);
            var created = await _tourRepo.CreateAsync(tour);
            return _mapper.Map<TourDto>(created);
        }

        public async Task<TourDto?> UpdateAsync(int id, UpdateTourDto dto)
        {

            var tour = await _tourRepo.GetByIdAsync(id);
            if (tour == null)
                throw new Exception("Tour not found");

            if (!string.IsNullOrWhiteSpace(dto.Title)) tour.Title = dto.Title;
            if (!string.IsNullOrWhiteSpace(dto.Description)) tour.Description = dto.Description;
            if (dto.Price.HasValue) tour.Price = dto.Price.Value;
            if (!string.IsNullOrWhiteSpace(dto.Region)) tour.Region = dto.Region;
            if (!string.IsNullOrWhiteSpace(dto.PhotoUrl)) tour.PhotoUrl = dto.PhotoUrl;
            if (dto.StartLatitude.HasValue) tour.StartLatitude = dto.StartLatitude.Value;
            if (dto.StartLongitude.HasValue) tour.StartLongitude = dto.StartLongitude.Value;
            tour.Status = dto.Status;
            await _tourRepo.SaveChangesAsync();
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
