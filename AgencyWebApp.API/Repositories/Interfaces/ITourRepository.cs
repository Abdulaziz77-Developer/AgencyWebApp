using AgencyWebApp.API.DTOs.TourDTOs;
using AgencyWebApp.API.DTOs.UserDTOs;
using AgencyWebApp.API.Models;

namespace AgencyWebApp.API.Repositories.Interfaces
{
    public interface ITourRepository : IBaseRepository<Tour, UpdateTourDto>
    {
        Task<List<Tour>> GetToursWithPointsAsync();
    }

}
