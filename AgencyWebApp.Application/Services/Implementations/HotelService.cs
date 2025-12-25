using AgencyWebApp.Application.DTOs.HotelDTOs;
using AgencyWebApp.Application.DTOs.MapDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;


namespace AgencyWebApp.Application.Services.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepo;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepo, IMapper mapper)
        {
            _hotelRepo = hotelRepo;
            _mapper = mapper;
        }

        public async Task<HotelDto?> GetByIdAsync(int id)
        {
            var hotel = await _hotelRepo.GetByIdAsync(id);
            return hotel == null ? null : _mapper.Map<HotelDto>(hotel);
        }

        public async Task<List<HotelDto>> GetAllAsync()
        {
            var hotels = await _hotelRepo.GetAllAsync();
            return _mapper.Map<List<HotelDto>>(hotels);
        }

        public async Task<HotelDto> CreateAsync(CreateHotelDto dto)
        {
            var hotel = _mapper.Map<Hotel>(dto);
            var created = await _hotelRepo.CreateAsync(hotel);
            return _mapper.Map<HotelDto>(created);
        }

        public async Task<HotelDto?> UpdateAsync(int id, UpdateHotelDto dto)
        {
            var hotel = await _hotelRepo.GetByIdAsync(id);
            if (hotel == null)
                throw new Exception("Hotel not found");

            // Строки — защищаемся от Swagger "string" и пустых значений
            if (!string.IsNullOrWhiteSpace(dto.Name))
                hotel.Name = dto.Name;

            if (!string.IsNullOrWhiteSpace(dto.Address))
                hotel.Address = dto.Address;

            if (!string.IsNullOrWhiteSpace(dto.City))
                hotel.City = dto.City;

            if (!string.IsNullOrWhiteSpace(dto.Country))
                hotel.Country = dto.Country;

            if (!string.IsNullOrWhiteSpace(dto.Description))
                hotel.Description = dto.Description;

            // Числовые поля
            if (dto.Latitude.HasValue)
                hotel.Latitude = dto.Latitude.Value;

            if (dto.Longitude.HasValue)
                hotel.Longitude = dto.Longitude.Value;

            await _hotelRepo.SaveChangesAsync();
            return _mapper.Map<HotelDto>(hotel);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _hotelRepo.DeleteAsync(id);
        }
        public async Task<List<HotelMapDto>> GetHotelsForMapAsync()
        {
            var hotels = await _hotelRepo.GetAllAsync();

            return hotels.Select(h => new HotelMapDto
            {
                Id = h.Id,
                Name = h.Name,
                Latitude = (double)h.Latitude,
                Longitude = (double)h.Longitude
            }).ToList();
        }
    }

}
