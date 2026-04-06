using AgencyWebApp.Application.Common;
using AgencyWebApp.Application.DTOs.FlightDto;
using AgencyWebApp.Application.DTOs.MapDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace AgencyWebApp.Application.Services.Implementations
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1); // Семафор для синхронизации доступа к кэшу

        public FlightService(IFlightRepository flightRepo, IMapper mapper, IMemoryCache cache)
        {
            _flightRepo = flightRepo;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<FlightDto?> GetByIdAsync(int id)
        {
            var flight = await _flightRepo.GetByIdAsync(id);
            return flight == null ? null : _mapper.Map<FlightDto>(flight);
        }

        public async Task<List<FlightDto>> GetAllAsync()
        {
            if (!_cache.TryGetValue(CacheKeys.FLIGHTS, out List<FlightDto>? cachedFlights))
            {
                await semaphore.WaitAsync();
                try
                {
                    if (!_cache.TryGetValue(CacheKeys.FLIGHTS, out cachedFlights))
                    {
                        Console.WriteLine("Cache Miss: Первый поток пошел в базу за данными...");
                        var flights = await _flightRepo.GetAllAsync();
                        cachedFlights = _mapper.Map<List<FlightDto>>(flights);
                        var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromHours(1)) // Данные "протухнут" через 1 час
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2))  // Если никто не заходит 2 минуты — кэш удалится раньше
                        .SetPriority(CacheItemPriority.High);           // Защищаем от случайного удаления при нехватке RAM
                        Console.WriteLine("Cache Miss: Loaded flights from database and stored in cache.");
                        _cache.Set(CacheKeys.FLIGHTS, cachedFlights, cacheOptions);
                    }
                    else
                    {
                        Console.WriteLine("Cache Hit: Данные взяты из кэша мгновенно.");
                    }
                }
                finally
                {
                    semaphore.Release();

                }
            }
            else
            {
                Console.WriteLine("Cache Hit: Данные взяты из кэша мгновенно.");
            }

            Console.WriteLine("Cache Hit: Returned flights from cache.");
            return cachedFlights!;  
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
