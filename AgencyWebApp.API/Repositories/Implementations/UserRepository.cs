using AgencyWebApp.API.Data;
using AgencyWebApp.API.DTOs.UserDTOs;
using AgencyWebApp.API.Models;
using AgencyWebApp.API.Repositories.Interfaces;

namespace AgencyWebApp.API.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User, UpdateUserDto>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }
    }

}
