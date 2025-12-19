using AgencyWebApp.API.DTOs.ReviewDTOs;
using AgencyWebApp.API.Models;
using AgencyWebApp.API.Repositories.Interfaces;
using AgencyWebApp.API.Services.Interfaces;
using AutoMapper;

namespace AgencyWebApp.API.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepo, IMapper mapper)
        {
            _reviewRepo = reviewRepo;
            _mapper = mapper;
        }

        public async Task<ReviewDto?> GetByIdAsync(int id)
        {
            var review = await _reviewRepo.GetByIdAsync(id);
            return review == null ? null : _mapper.Map<ReviewDto>(review);
        }

        public async Task<List<ReviewDto>> GetAllAsync()
        {
            var reviews = await _reviewRepo.GetAllAsync();
            return _mapper.Map<List<ReviewDto>>(reviews);
        }

        public async Task<ReviewDto> CreateAsync(CreateReviewDto dto)
        {
            var review = _mapper.Map<Review>(dto);
            var created = await _reviewRepo.CreateAsync(review);
            return _mapper.Map<ReviewDto>(created);
        }

        public async Task<ReviewDto?> UpdateAsync(int id, UpdateReviewDto dto)
        {
            var updated = await _reviewRepo.UpdateAsync(id, dto);
            return updated == null ? null : _mapper.Map<ReviewDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _reviewRepo.DeleteAsync(id);
        }
    }

}
