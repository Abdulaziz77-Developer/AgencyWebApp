using AgencyWebApp.API.DTOs.FlightDto;
using AgencyWebApp.API.DTOs.MapDTOs;
using AgencyWebApp.API.Models;
using AgencyWebApp.API.Repositories.Implementations;
using AgencyWebApp.API.Repositories.Interfaces;
using AgencyWebApp.API.Services.Interfaces;
using AutoMapper;

namespace AgencyWebApp.API.Services.Implementations
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepo;
        private readonly IMapper _mapper;

        public FlightService(IFlightRepository flightRepo, IMapper mapper)
        {
            _flightRepo = flightRepo;
            _mapper = mapper;
        }

        public async Task<FlightDto?> GetByIdAsync(int id)
        {
            var flight = await _flightRepo.GetByIdAsync(id);
            return flight == null ? null : _mapper.Map<FlightDto>(flight);
        }

        public async Task<List<FlightDto>> GetAllAsync()
        {
            var flights = await _flightRepo.GetAllAsync();
            return _mapper.Map<List<FlightDto>>(flights);
        }

        public async Task<FlightDto> CreateAsync(CreateFlightDto dto)
        {
            var flight = _mapper.Map<Flight>(dto);
            var created = await _flightRepo.CreateAsync(flight);
            return _mapper.Map<FlightDto>(created);
        }

        public async Task<FlightDto?> UpdateAsync(int id, UpdateFlightDto dto)
        {
            var updated = await _flightRepo.UpdateAsync(id, dto);
            return updated == null ? null : _mapper.Map<FlightDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _flightRepo.DeleteAsync(id);
        }
        public async Task<List<FlightMapDto>> GetFlightsForMapAsync()
        {
            var flights = await _flightRepo.GetAllAsync();

            return flights.Select(f => new FlightMapDto
            {
                Id = f.Id,
                FromLatitude = (double)f.FromLatitude,
                FromLongitude = (double)f.FromLongitude,
                ToLatitude = (double)f.ToLatitude,
                ToLongitude = (double)f.ToLongitude
            }).ToList();
        }
    }
}
