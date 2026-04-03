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
            if (!_cache.TryGetValue(CacheKeys.REVIEWS, out List<ReviewDto>? cachedReviews))
            {
                // 2. Если в кэше ПУСТО (Cache Miss), идем в базу данных
                var reviews = await _reviewRepo.GetAllAsync();

                // Маппим сущности в DTO
                cachedReviews = _mapper.Map<List<ReviewDto>>(reviews);

                // 3. Настраиваем политику кэширования
                var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromHours(1)) // Данные "протухнут" через 1 час
                .SetSlidingExpiration(TimeSpan.FromMinutes(2))  // Если никто не заходит 2 минуты — кэш удалится раньше
                .SetPriority(CacheItemPriority.High);           // Защищаем от случайного удаления при нехватке RAM
                Console.WriteLine("Cache Miss: Loaded reviews from database and stored in cache.");
                // 4. Сохраняем результат в кэш
                _cache.Set(CacheKeys.REVIEWS, cachedReviews, cacheOptions);
            }

            // 5. Возвращаем либо данные из кэша, либо свежезагруженные
            Console.WriteLine("Cache Hit: Returned reviews from cache.");
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
