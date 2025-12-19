using AgencyWebApp.API.DTOs.MapDTOs;
using AgencyWebApp.API.DTOs.TourDTOs;
using AgencyWebApp.API.Models;
using AgencyWebApp.API.Repositories.Implementations;
using AgencyWebApp.API.Repositories.Interfaces;
using AgencyWebApp.API.Services.Interfaces;
using AutoMapper;

namespace AgencyWebApp.API.Services.Implementations
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepo;
        private readonly IMapper _mapper;

        public TourService(ITourRepository tourRepo, IMapper mapper)
        {
            _tourRepo = tourRepo;
            _mapper = mapper;
        }

        public async Task<TourDto?> GetByIdAsync(int id)
        {
            var tour = await _tourRepo.GetByIdAsync(id);
            return tour == null ? null : _mapper.Map<TourDto>(tour);
        }

        public async Task<List<TourDto>> GetAllAsync()
        {
            var tours = await _tourRepo.GetAllAsync();
            return _mapper.Map<List<TourDto>>(tours);
        }

        public async Task<TourDto> CreateAsync(CreateTourDto dto)
        {
            var tour = _mapper.Map<Tour>(dto);
            var created = await _tourRepo.CreateAsync(tour);
            return _mapper.Map<TourDto>(created);
        }

        public async Task<TourDto?> UpdateAsync(int id, UpdateTourDto dto)
        {
            var updated = await _tourRepo.UpdateAsync(id, dto);
            return updated == null ? null : _mapper.Map<TourDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _tourRepo.DeleteAsync(id);
        }
        public async Task<List<TourMapDto>> GetToursForMapAsync()
        {
            var tours = await _tourRepo.GetAllAsync();

            return tours.Select(t => new TourMapDto
            {
                Id = t.Id,
                Title = t.Title,
                StartLatitude = (double)t.StartLatitude,
                StartLongitude = (double)t.StartLongitude
            }).ToList();
        }

    }

}
