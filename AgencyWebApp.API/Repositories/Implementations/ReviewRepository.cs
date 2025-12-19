using AgencyWebApp.API.Data;
using AgencyWebApp.API.DTOs.ReviewDTOs;
using AgencyWebApp.API.Models;
using AgencyWebApp.API.Repositories.Interfaces;

namespace AgencyWebApp.API.Repositories.Implementations
{
    public class ReviewRepository : BaseRepository<Review, UpdateReviewDto>, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context) { }
    }

}
