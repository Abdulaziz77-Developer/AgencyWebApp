using AgencyWebApp.Application.DTOs.MapDTOs;
using AgencyWebApp.Application.DTOs.TourDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;


namespace AgencyWebApp.Application.Services.Implementations
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

            var tour = await _tourRepo.GetByIdAsync(id);
            if (tour == null)
                throw new Exception("Tour not found");

            if (!string.IsNullOrWhiteSpace(dto.Title)) tour.Title = dto.Title;
            if (!string.IsNullOrWhiteSpace(dto.Description)) tour.Description = dto.Description;
            if (dto.Price.HasValue) tour.Price = dto.Price.Value;
            if (!string.IsNullOrWhiteSpace(dto.Region)) tour.Region = dto.Region;
            if (!string.IsNullOrWhiteSpace(dto.PhotoUrl)) tour.PhotoUrl = dto.PhotoUrl;
            if (dto.StartLatitude.HasValue) tour.StartLatitude = dto.StartLatitude.Value;
            if (dto.StartLongitude.HasValue) tour.StartLongitude = dto.StartLongitude.Value;
            tour.Status = dto.Status;
            await _tourRepo.SaveChangesAsync();
            return _mapper.Map<TourDto>(tour);
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
