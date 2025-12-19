using AgencyWebApp.API.DTOs.HotelDTOs;
using AgencyWebApp.API.DTOs.MapDTOs;

namespace AgencyWebApp.API.Services.Interfaces
{
    public interface IHotelService
    {
        Task<HotelDto?> GetByIdAsync(int id);
        Task<List<HotelDto>> GetAllAsync();
        Task<HotelDto> CreateAsync(CreateHotelDto dto);
        Task<HotelDto?> UpdateAsync(int id, UpdateHotelDto dto);
        Task<bool> DeleteAsync(int id);

        Task<List<HotelMapDto>> GetHotelsForMapAsync();
    }

}
