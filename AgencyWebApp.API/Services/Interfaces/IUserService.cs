using AgencyWebApp.API.DTOs.UserDTOs;

namespace AgencyWebApp.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> GetByIdAsync(int id);
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> CreateAsync(CreateUserDto dto);
        Task<UserDto?> UpdateAsync(int id, UpdateUserDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
