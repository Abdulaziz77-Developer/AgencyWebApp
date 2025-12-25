namespace AgencyWebApp.Domain.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
