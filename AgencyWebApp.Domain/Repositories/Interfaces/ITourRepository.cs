using AgencyWebApp.Domain.Models;

namespace AgencyWebApp.Domain.Repositories.Interfaces
{
    public interface ITourRepository : IBaseRepository<Tour>
    {
        Task<List<Tour>> GetToursWithPointsAsync();
    }

}
