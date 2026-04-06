using AgencyWebApp.Application.DTOs.UserDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;

namespace AgencyWebApp.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
          
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepo.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            var _user = await _userRepo.GetByEmailAsync(dto.Email);
            if (_user != null)
            {
                throw new Exception("User with this email already exists");
            }  
            var created = await _userRepo.CreateAsync(user);
            return _mapper.Map<UserDto>(created);
        }

        public async Task<UserDto?> UpdateAsync(int id, UpdateUserDto dto)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
                throw new Exception("User not found");

            // Имя
            if (!string.IsNullOrWhiteSpace(dto.FullName))
                user.FullName = dto.FullName;

            // Email
            if (!string.IsNullOrWhiteSpace(dto.Email))
                user.Email = dto.Email;

            // Пароль (ТОЛЬКО через хэш)
            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            }

            // Роль (обычно только админ)
            if (dto.Role.HasValue)
            {
                user.Role = dto.Role.Value;
            }

            // Координаты
            if (dto.HomeLatitude.HasValue)
                user.HomeLatitude = dto.HomeLatitude.Value;

            if (dto.HomeLongitude.HasValue)
                user.HomeLongitude = dto.HomeLongitude.Value;

            await _userRepo.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepo.DeleteAsync(id);
        }
    }

}
