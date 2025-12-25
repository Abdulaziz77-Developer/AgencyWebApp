using AgencyWebApp.Application.DTOs.FlightDto;
using AgencyWebApp.Application.DTOs.MapDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;

namespace AgencyWebApp.Application.Services.Implementations
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
            var flight = await _flightRepo.GetByIdAsync(id);
            if (flight == null)
                throw new Exception("Flight not found");

            if (!string.IsNullOrWhiteSpace(dto.AirPlaneName)) flight.AirPlaneName = dto.AirPlaneName;
            if (!string.IsNullOrWhiteSpace(dto.FromCity)) flight.FromCity = dto.FromCity;
            if (!string.IsNullOrWhiteSpace(dto.ToCity)) flight.ToCity = dto.ToCity;

            if (dto.FlightNumber.HasValue) flight.FlightNumber = dto.FlightNumber.Value;
            if (dto.DepartureTime.HasValue) flight.DepartureTime = dto.DepartureTime.Value;
            if (dto.ArrivalTime.HasValue) flight.ArrivalTime = dto.ArrivalTime.Value;
            if (dto.FromLatitude.HasValue) flight.FromLatitude = dto.FromLatitude.Value;
            if (dto.FromLongitude.HasValue) flight.FromLongitude = dto.FromLongitude.Value;
            if (dto.ToLatitude.HasValue) flight.ToLatitude = dto.ToLatitude.Value;
            if (dto.ToLongitude.HasValue) flight.ToLongitude = dto.ToLongitude.Value;
            await _flightRepo.SaveChangesAsync();
            return _mapper.Map<FlightDto>(flight);
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
