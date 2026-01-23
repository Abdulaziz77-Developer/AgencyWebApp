using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AgencyWebApp.Infrastructure.Data;

namespace AgencyWebApp.Infrastructure.Repositories.Implementations
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context) { }
    }

}
