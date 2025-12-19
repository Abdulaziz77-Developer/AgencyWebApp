using AgencyWebApp.API.DTOs.AuthDTOs;
using AgencyWebApp.API.DTOs.UserDTOs;

namespace AgencyWebApp.API.Auth.Interfaces_
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }

}
