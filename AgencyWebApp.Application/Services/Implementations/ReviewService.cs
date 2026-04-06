using AgencyWebApp.Application.Common;
using AgencyWebApp.Application.DTOs.ReviewDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;


namespace AgencyWebApp.Application.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private readonly  IValidator<CreateReviewDto> _createValidator;
        private readonly IValidator<UpdateReviewDto> _updateValidator;

        public ReviewService(IReviewRepository reviewRepo, IMapper mapper, IMemoryCache cache, IValidator<UpdateReviewDto> updateValidator, IValidator<CreateReviewDto> createValidator)
        {
            _reviewRepo = reviewRepo;
            _mapper = mapper;
            _cache = cache;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
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
            // 1. Perform validation
            var validationResult = await _createValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                // Extract the specific error message from the validator
                var errorMessage = validationResult.Errors.First().ErrorMessage;
                throw new Exception(errorMessage);
            }

            // 2. Map DTO to the Review entity
            var review = _mapper.Map<Review>(dto);

            // 3. Save the new review to the database
            var created = await _reviewRepo.CreateAsync(review);

            // 4. Return the result as a ReviewDto
            return _mapper.Map<ReviewDto>(created);
        }

        public async Task<ReviewDto?> UpdateAsync(int id, UpdateReviewDto dto)
        {
            // 1. Validate the incoming update request
            var validationResult = await _updateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                // Extract the error message defined in UpdateReviewDtoValidator
                var errorMessage = validationResult.Errors.First().ErrorMessage;
                throw new Exception(errorMessage);
            }

            // 2. Retrieve the existing review from the database
            var review = await _reviewRepo.GetByIdAsync(id);
            if (review == null)
                throw new Exception("Review not found");

            // 3. Map non-null values from DTO to the existing entity
            // This replaces all manual "if (dto.Field.HasValue)" checks
            _mapper.Map(dto, review);

            // 4. Save changes to the database
            await _reviewRepo.SaveChangesAsync();

            // 5. Return the updated result as a DTO
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _reviewRepo.DeleteAsync(id);
        }
    }

}
