using AgencyWebApp.Application.DTOs.FlightDto;
using AgencyWebApp.Application.DTOs.MapDTOs;

namespace AgencyWebApp.Application.Services.Interfaces
{
    public interface IFlightService
    {
        Task<FlightDto?> GetByIdAsync(int id);
        Task<List<FlightDto>> GetAllAsync();
        Task<FlightDto> CreateAsync(CreateFlightDto dto);
        Task<FlightDto?> UpdateAsync(int id, UpdateFlightDto dto);
        Task<bool> DeleteAsync(int id);

        Task<List<FlightMapDto>> GetFlightsForMapAsync();
    }

}
