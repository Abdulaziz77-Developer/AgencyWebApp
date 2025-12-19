using AgencyWebApp.API.DTOs.UserDTOs;
using AgencyWebApp.API.Models;

namespace AgencyWebApp.API.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User, UpdateUserDto>
    {
    }
}
