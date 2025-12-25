using AgencyWebApp.Application.DTOs.AuthDTOs;
using AgencyWebApp.Application.DTOs.UserDTOs;

namespace AgencyWebApp.Application.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }

}
