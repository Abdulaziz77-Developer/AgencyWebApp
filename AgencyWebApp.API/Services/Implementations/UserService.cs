using AgencyWebApp.API.DTOs.UserDTOs;
using AgencyWebApp.API.Models;
using AgencyWebApp.API.Repositories.Interfaces;
using AgencyWebApp.API.Services.Interfaces;
using AutoMapper;

namespace AgencyWebApp.API.Services.Implementations
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
            var created = await _userRepo.CreateAsync(user);
            return _mapper.Map<UserDto>(created);
        }

        public async Task<UserDto?> UpdateAsync(int id, UpdateUserDto dto)
        {
            var updated = await _userRepo.UpdateAsync(id, dto);
            return updated == null ? null : _mapper.Map<UserDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepo.DeleteAsync(id);
        }
    }

}
