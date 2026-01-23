using AgencyWebApp.Application.DTOs.ReviewDTOs;

namespace AgencyWebApp.Application.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDto?> GetByIdAsync(int id);
        Task<List<ReviewDto>> GetAllAsync();
        Task<ReviewDto> CreateAsync(CreateReviewDto dto);
        Task<ReviewDto?> UpdateAsync(int id, UpdateReviewDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
