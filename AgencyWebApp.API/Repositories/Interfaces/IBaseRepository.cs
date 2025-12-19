namespace AgencyWebApp.API.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity,TUpdateDto> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity?> UpdateAsync(int id, TUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
