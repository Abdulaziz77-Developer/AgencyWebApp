using AgencyWebApp.Application.DTOs.HotelDTOs;
using AgencyWebApp.Application.DTOs.MapDTOs;

namespace AgencyWebApp.Application.Services.Interfaces
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
