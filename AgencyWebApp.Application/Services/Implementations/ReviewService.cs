using AgencyWebApp.Application.DTOs.ReviewDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;


namespace AgencyWebApp.Application.Services.Implementations
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
