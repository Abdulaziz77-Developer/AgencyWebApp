using AgencyWebApp.API.DTOs.ReviewDTOs;
using AgencyWebApp.API.Models;

namespace AgencyWebApp.API.Repositories.Interfaces
{
    public interface IReviewRepository : IBaseRepository<Review,UpdateReviewDto>
    {
    }
}
