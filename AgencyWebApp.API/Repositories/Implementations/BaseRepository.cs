using AgencyWebApp.API.Data;
using AgencyWebApp.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgencyWebApp.API.Repositories.Implementations
{
    public class BaseRepository<TEntity, TUpdateDto> : IBaseRepository<TEntity, TUpdateDto>
    where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id) =>
            await _dbSet.FindAsync(id);

        public virtual async Task<List<TEntity>> GetAllAsync() =>
            await _dbSet.ToListAsync();

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, object updateDto)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                throw new Exception($"{typeof(TEntity).Name} not found");

            var entry = _context.Entry(entity);

            foreach (var prop in updateDto.GetType().GetProperties())
            {
                var value = prop.GetValue(updateDto);

                // проверяем на null / пустую строку / 0
                if (value != null && !(value is string s && string.IsNullOrWhiteSpace(s)) && value.ToString() != "string" && value.ToString() != "0")
                {
                    var entityProp = typeof(TEntity).GetProperty(prop.Name);
                    if (entityProp != null)
                    {
                        entityProp.SetValue(entity, value);
                        entry.Property(prop.Name).IsModified = true;
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
