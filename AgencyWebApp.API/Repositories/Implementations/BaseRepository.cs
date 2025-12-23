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

        public virtual async Task<TEntity?> UpdateAsync(int id, TUpdateDto dto)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return null;

            var dtoProperties = typeof(TUpdateDto).GetProperties();
            var entityProperties = typeof(TEntity).GetProperties();

            foreach (var prop in dtoProperties)
            {
                var value = prop.GetValue(dto);
                bool shouldUpdate = false;

                if (value != null)
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        var str = value as string;
                        shouldUpdate = !string.IsNullOrWhiteSpace(str) && str != "string";
                    }
                    else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(double) || prop.PropertyType == typeof(float))
                    {
                        shouldUpdate = Convert.ToDecimal(value) != 0;
                    }
                    else
                    {
                        
                        shouldUpdate = true;
                    }
                }

                if (!shouldUpdate) continue;

                var entityProp = entityProperties.FirstOrDefault(p => p.Name == prop.Name && p.PropertyType == prop.PropertyType);
                if (entityProp != null && entityProp.CanWrite)
                {
                    entityProp.SetValue(entity, value);
                }
            }

            await _context.SaveChangesAsync();
            return entity;
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
