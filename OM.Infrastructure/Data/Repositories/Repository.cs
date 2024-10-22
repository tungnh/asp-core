using Microsoft.EntityFrameworkCore;
using OM.Application.Data.Repositories;
using OM.Domain;
using System.Linq.Expressions;

namespace OM.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TEntity? Find(params object?[]? keyValues)
        {
            return _context.Set<TEntity>().Find(keyValues);
        }

        public async Task<TEntity?> FindAsync(params object?[]? keyValues)
        {
            return await _context.Set<TEntity>().FindAsync(keyValues);
        }

        public TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public List<TEntity> FindAll(bool ignoreDeleteFlg = false)
        {
            return _context.Set<TEntity>().ToList();
        }

        public async Task<List<TEntity>> FindAllAsync(bool ignoreDeleteFlg = false)
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            if (entity is BaseEntity entityBase)
            {
                entityBase.CreatedBy = "TODO";
                entityBase.CreatedAt = DateTime.Now;
            }
            _context.Set<TEntity>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is BaseEntity entityBase)
                {
                    entityBase.CreatedBy = "TODO";
                    entityBase.CreatedAt = DateTime.Now;
                }
            }
            _context.Set<TEntity>().AddRange(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            if (entity is BaseEntity entityBase)
            {
                entityBase.LastModifiedBy = "TODO";
                entityBase.LastModifiedAt = DateTime.Now;
            }
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is BaseEntity entityBase)
                {
                    entityBase.LastModifiedBy = "TODO";
                    entityBase.LastModifiedAt = DateTime.Now;
                }
            }
            _context.Set<TEntity>().UpdateRange(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SoftRemoveAsync(TEntity entity)
        {
            if (entity is BaseEntity entityBase)
            {
                entityBase.DeleteFlg = true;
                entityBase.LastModifiedBy = "TODO";
                entityBase.LastModifiedAt = DateTime.Now;
            }
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SoftRemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is BaseEntity entityBase)
                {
                    entityBase.DeleteFlg = true;
                    entityBase.LastModifiedBy = "TODO";
                    entityBase.LastModifiedAt = DateTime.Now;
                }
            }
            _context.Set<TEntity>().UpdateRange(entities);
            return await _context.SaveChangesAsync();
        }

        public bool ExistsById(params object?[]? keyValues)
        {
            var entity = _context.Set<TEntity>().Find(keyValues);
            return entity != null;
        }
    }
}
