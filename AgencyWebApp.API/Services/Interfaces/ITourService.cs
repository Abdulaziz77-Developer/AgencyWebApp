using AgencyWebApp.API.DTOs.MapDTOs;
using AgencyWebApp.API.DTOs.TourDTOs;

namespace AgencyWebApp.API.Services.Interfaces
{
    public interface ITourService
    {
        Task<TourDto?> GetByIdAsync(int id);
        Task<List<TourDto>> GetAllAsync();
        Task<TourDto> CreateAsync(CreateTourDto dto);
        Task<TourDto?> UpdateAsync(int id, UpdateTourDto dto);
        Task<bool> DeleteAsync(int id);

        Task<List<TourMapDto>> GetToursForMapAsync();
    }

}
