using AgencyWebApp.Application.Common;
using AgencyWebApp.Application.DTOs.FlightDto;
using AgencyWebApp.Application.DTOs.MapDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Application.Validators.FlightValidators;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;

namespace AgencyWebApp.Application.Services.Implementations
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1); 
        private readonly IValidator<CreateFlightDto> _createValidator;
        private readonly IValidator<UpdateFlightDto> _updateValidator;

        public FlightService(IFlightRepository flightRepo, IMapper mapper, IMemoryCache cache, IValidator<UpdateFlightDto> updateValidator, IValidator<CreateFlightDto> createValidator)

        {
            _flightRepo = flightRepo;
            _mapper = mapper;
            _cache = cache;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
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
            
            var validationResult = await _createValidator.ValidateAsync(dto);

         
            if (!validationResult.IsValid)
            {
                var errorMessage = validationResult.Errors.First().ErrorMessage;
                throw new Exception(errorMessage);
            }
                        
            var flight = _mapper.Map<Flight>(dto);
                       
            var created = await _flightRepo.CreateAsync(flight);

            return _mapper.Map<FlightDto>(created);
        }

        public async Task<FlightDto?> UpdateAsync(int id, UpdateFlightDto dto)
        {
            // 1. Валидация входящих данных (проверяем координаты и логику дат)
            var validationResult = await _updateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                // Выбрасываем первую ошибку из списка
                var errorMessage = validationResult.Errors.First().ErrorMessage;
                throw new Exception(errorMessage);
            }

            // 2. Поиск существующего рейса
            var flight = await _flightRepo.GetByIdAsync(id);
            if (flight == null)
                throw new Exception("Flight not found");

            // 3. Умный маппинг через AutoMapper
            // Он автоматически обновит только те поля, которые не null в UpdateFlightDto
            _mapper.Map(dto, flight);

            // 4. Сохранение изменений в БД
            await _flightRepo.SaveChangesAsync();

            // 5. Возвращаем результат
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
