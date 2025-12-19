using AgencyWebApp.API.DTOs.HotelDTOs;
using AgencyWebApp.API.DTOs.MapDTOs;
using AgencyWebApp.API.Models;
using AgencyWebApp.API.Repositories.Implementations;
using AgencyWebApp.API.Repositories.Interfaces;
using AgencyWebApp.API.Services.Interfaces;
using AutoMapper;

namespace AgencyWebApp.API.Services.Implementations
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
            var hotel = new Hotel();
            if (!string.IsNullOrWhiteSpace(dto.Name) && dto.Name != "string")
                hotel.Name = dto.Name;

            if (!string.IsNullOrWhiteSpace(dto.Address) && dto.Address != "string")
                hotel.Address = dto.Address;

            if (!string.IsNullOrWhiteSpace(dto.City) && dto.City != "string")
                hotel.City = dto.City;

            if (dto.Latitude.HasValue && dto.Latitude.Value != 0)
                hotel.Latitude = dto.Latitude.Value;

            if (dto.Longitude.HasValue && dto.Longitude.Value != 0)
                hotel.Longitude = dto.Longitude.Value;

            var updated = await _hotelRepo.UpdateAsync(id, _mapper.Map<UpdateHotelDto>(hotel));
            return updated == null ? null : _mapper.Map<HotelDto>(updated);
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
