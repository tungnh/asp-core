using Microsoft.EntityFrameworkCore;
using OM.Application.Data.Repositories;
using OM.Application.Models.Paging;
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

        public async Task<TEntity?> FindAsync(params object?[]? keyValues)
        {
            return await _context.Set<TEntity>().FindAsync(keyValues);
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> FindAllAsync(bool ignoreDeleteFlg = false)
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<List<TEntity>> FindAllAsync(string[]? sort, bool ignoreDeleteFlg = false)
        {
            var source = _context.Set<TEntity>().AsQueryable<TEntity>();
            // Sort
            source = OrderQueryable(source, sort);

            return await source.AsNoTracking().ToListAsync();
        }

        public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, bool ignoreDeleteFlg = false)
        {
            return await _context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<PaginatedList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, Pageable pageable, bool ignoreDeleteFlg = false)
        {
            var source = _context.Set<TEntity>().Where(predicate);
            // Count total elements
            var count = await source.AsNoTracking().CountAsync();
            // Sort
            source = OrderQueryable(source, pageable.Sort);
            // Paging
            var items = await source.Skip(pageable.PageIndex * pageable.PageSize)
                .Take(pageable.PageSize)
                .AsNoTracking()
                .ToListAsync();

            return new PaginatedList<TEntity>(items, count, pageable.PageIndex, pageable.PageSize);
        }

        public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, string[]? sort, bool ignoreDeleteFlg = false)
        {
            var source = _context.Set<TEntity>().Where(predicate);
            // Sort
            source = OrderQueryable(source, sort);

            return await source.AsNoTracking().ToListAsync();
        }

        private IQueryable<TEntity> OrderQueryable(IQueryable<TEntity> source, string[]? sort)
        {
            if (sort != null)
            {
                bool isFirst = true;
                var paramExpression = Expression.Parameter(typeof(TEntity));
                foreach (var itemSort in sort)
                {
                    var sortArr = itemSort.Split(",");
                    var sortProperty = sortArr[0];
                    var sortDirection = sortArr.Length > 1 && sortArr[1].ToLower().Equals("desc") ? OrderDirection.DESC : OrderDirection.ASC;
                    var sortExpression = Expression.Lambda<Func<TEntity, object>>
                            (Expression.Convert(Expression.Property(paramExpression, sortProperty), typeof(object)), paramExpression);

                    switch (sortDirection)
                    {
                        case OrderDirection.ASC:
                            source = isFirst ? source.OrderBy(sortExpression) : ((IOrderedQueryable<TEntity>)source).ThenBy(sortExpression);
                            break;
                        case OrderDirection.DESC:
                            source = isFirst ? source.OrderByDescending(sortExpression) : ((IOrderedQueryable<TEntity>)source).ThenByDescending(sortExpression);
                            break;
                    }
                    isFirst = false;
                }
            }
            return source;
        }

        public async Task<int> AddAsync(TEntity entity, string userId)
        {
            if (entity is BaseEntity entityBase)
            {
                entityBase.CreatedBy = userId;
                entityBase.CreatedAt = DateTime.Now;
            }
            _context.Set<TEntity>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities, string userId)
        {
            foreach (var entity in entities)
            {
                if (entity is BaseEntity entityBase)
                {
                    entityBase.CreatedBy = userId;
                    entityBase.CreatedAt = DateTime.Now;
                }
            }
            _context.Set<TEntity>().AddRange(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity, string? userId = null)
        {
            if (entity is BaseEntity entityBase)
            {
                entityBase.LastModifiedBy = userId;
                entityBase.LastModifiedAt = DateTime.Now;
            }
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities, string? userId = null)
        {
            foreach (var entity in entities)
            {
                if (entity is BaseEntity entityBase)
                {
                    entityBase.LastModifiedBy = userId;
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

        public async Task<int> SoftRemoveAsync(TEntity entity, string? userId = null)
        {
            if (entity is BaseEntity entityBase)
            {
                entityBase.DeleteFlg = true;
                entityBase.LastModifiedBy = userId;
                entityBase.LastModifiedAt = DateTime.Now;
            }
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SoftRemoveRangeAsync(IEnumerable<TEntity> entities, string? userId = null)
        {
            foreach (var entity in entities)
            {
                if (entity is BaseEntity entityBase)
                {
                    entityBase.DeleteFlg = true;
                    entityBase.LastModifiedBy = userId;
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
