using AgencyWebApp.Application.Common;
using AgencyWebApp.Application.DTOs.ReviewDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;


namespace AgencyWebApp.Application.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1); // Семафор для синхронизации доступа к кэшу

        public ReviewService(IReviewRepository reviewRepo, IMapper mapper, IMemoryCache cache)
        {
            _reviewRepo = reviewRepo;
            _mapper = mapper;
            _cache = cache;

        }

        public async Task<ReviewDto?> GetByIdAsync(int id)
        {
            var review = await _reviewRepo.GetByIdAsync(id);
            return review == null ? null : _mapper.Map<ReviewDto>(review);
        }

        public async Task<List<ReviewDto>> GetAllAsync()
        {
            // Шаг 1: Быстрая проверка кэша (без блокировки)
            if (!_cache.TryGetValue(CacheKeys.REVIEWS, out List<ReviewDto>? cachedReviews))
            {
                // Шаг 2: Если кэша нет, ждем своей очереди у "турникета"
                await semaphore.WaitAsync();

                try
                {
                    // Шаг 3: Двойная проверка (Double-Check Locking)
                    // Пока мы ждали в очереди, первый поток мог уже записать данные в кэш!
                    if (!_cache.TryGetValue(CacheKeys.REVIEWS, out cachedReviews))
                    {
                        Console.WriteLine("Cache Miss: Первый поток пошел в базу за данными...");

                        var reviews = await _reviewRepo.GetAllAsync();
                        cachedReviews = _mapper.Map<List<ReviewDto>>(reviews);

                        var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromHours(1))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2))
                        .SetPriority(CacheItemPriority.High);

                        _cache.Set(CacheKeys.REVIEWS, cachedReviews, cacheOptions);
                    }
                    else
                    {
                        Console.WriteLine("Cache Hit: Мы подождали в очереди, и данные уже появились в кэше!");
                    }
                }

                finally
                {
                    // Шаг 4: ОБЯЗАТЕЛЬНО освобождаем турникет для других
                    semaphore.Release();
                }
            }
            else
            {
                Console.WriteLine("Cache Hit: Данные взяты из кэша мгновенно.");
            }

        return cachedReviews!;

    }
        public async Task<ReviewDto> CreateAsync(CreateReviewDto dto)
        {
            var review = _mapper.Map<Review>(dto);
            var created = await _reviewRepo.CreateAsync(review);
            return _mapper.Map<ReviewDto>(created);
        }

        public async Task<ReviewDto?> UpdateAsync(int id, UpdateReviewDto dto)
        {
            var review = await _reviewRepo.GetByIdAsync(id);
            if (review == null)
                throw new Exception("Review not found");

            // Текст — защищаемся от пустых и swagger "string"
            if (!string.IsNullOrWhiteSpace(dto.Text))
                review.Text = dto.Text;

            // Связи — только если реально пришли
            if (dto.TourId.HasValue)
                review.TourId = dto.TourId.Value;

            if (dto.HotelId.HasValue)
                review.HotelId = dto.HotelId.Value;

            if (dto.FlightId.HasValue)
                review.FlightId = dto.FlightId.Value;

            await _reviewRepo.SaveChangesAsync();
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _reviewRepo.DeleteAsync(id);
        }
    }

}
