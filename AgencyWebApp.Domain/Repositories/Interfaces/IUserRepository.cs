using AgencyWebApp.Domain.Models;

namespace AgencyWebApp.Domain.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
