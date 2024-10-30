using Microsoft.EntityFrameworkCore;
using OM.Application.Data.Repositories;
using OM.Application.Models.Paging;
using OM.Application.Utils;
using OM.Domain;
using System.Linq.Expressions;

namespace OM.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the Repository class.
        /// </summary>
        /// <param name="context">The ApplicationDbContext instance.</param>
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Asynchronously finds an entity with the given key values.
        /// </summary>
        /// <param name="keyValues">The values of the primary key for the entity to be found.</param>
        /// <returns>A task that represents the asynchronous find operation. The task result contains the entity found, or the default value of TEntity if no entity is found.</returns>
        public async Task<TEntity?> FindAsync(params object?[]? keyValues)
        {
            return await _context.Set<TEntity>().FindAsync(keyValues);
        }

        /// <summary>
        /// Asynchronously finds the first entity that matches the given predicate.
        /// </summary>
        /// <param name="predicate">A function to test each entity for a condition.</param>
        /// <returns>The first entity that matches the predicate, or the default value of TEntity if no entity matches.</returns>
        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Asynchronously retrieves a list of all entities of type TEntity.
        /// </summary>
        /// <param name="ignoreDeleteFlg">Optional flag to ignore the deletion flag of entities. Defaults to false.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of TEntity objects.</returns>
        public async Task<List<TEntity>> FindAllAsync(bool ignoreDeleteFlg = false)
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a list of all entities of type TEntity, 
        /// sorted according to the provided sort parameters.
        /// </summary>
        /// <param name="sort">An array of strings representing the sort parameters.</param>
        /// <param name="ignoreDeleteFlg">Optional flag to ignore the deletion flag of entities. Defaults to false.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of TEntity objects.</returns>
        public async Task<List<TEntity>> FindAllAsync(string[]? sort, bool ignoreDeleteFlg = false)
        {
            var source = _context.Set<TEntity>().AsQueryable<TEntity>();
            // Sort
            source = OrderQueryable(source, sort);

            return await source.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a list of entities of type TEntity that match the given predicate.
        /// </summary>
        /// <param name="predicate">A function to test each entity in the set for a condition.</param>
        /// <param name="ignoreDeleteFlg">Optional flag to ignore the deletion flag of entities. Defaults to false.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of TEntity objects.</returns>
        public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, bool ignoreDeleteFlg = false)
        {
            return await _context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a list of entities of type TEntity that match the given predicate, 
        /// sorted according to the provided pageable parameters, and paginated.
        /// </summary>
        /// <param name="predicate">A function to test each entity in the set for a condition.</param>
        /// <param name="pageable">An object containing pagination and sorting parameters.</param>
        /// <param name="ignoreDeleteFlg">Optional flag to ignore the deletion flag of entities. Defaults to false.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a PaginatedList of TEntity objects.</returns>
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

        /// <summary>
        /// Asynchronously retrieves a list of entities of type TEntity that match the given predicate, 
        /// sorted according to the provided sort parameters.
        /// </summary>
        /// <param name="predicate">A function to test each entity in the set for a condition.</param>
        /// <param name="sort">An array of strings representing the sort parameters.</param>
        /// <param name="ignoreDeleteFlg">Optional flag to ignore the deletion flag of entities. Defaults to false.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of TEntity objects.</returns>
        public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, string[]? sort, bool ignoreDeleteFlg = false)
        {
            var source = _context.Set<TEntity>().Where(predicate);
            // Sort
            source = OrderQueryable(source, sort);

            return await source.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Applies sorting to the given query source based on the provided sort parameters.
        /// </summary>
        /// <param name="source">The query source to be sorted.</param>
        /// <param name="sort">An array of strings representing the sort parameters, where each string is in the format "property_name,asc|desc".</param>
        /// <returns>The sorted query source.</returns>
        private IQueryable<TEntity> OrderQueryable(IQueryable<TEntity> source, string[]? sort)
        {
            if (sort != null && sort.Length != 0)
            {
                bool isFirst = true;
                var paramExpression = Expression.Parameter(typeof(TEntity));
                foreach (var itemSort in sort)
                {
                    var sortArr = itemSort.Split(Constants.Comma);
                    var sortProperty = sortArr[0];
                    var sortDirection = sortArr.Length > 1 && sortArr[1].ToLower().Equals(OrderDirection.Desc) ? OrderDirection.Desc : OrderDirection.Asc;
                    var sortExpression = Expression.Lambda<Func<TEntity, object>>
                            (Expression.Convert(Expression.Property(paramExpression, sortProperty), typeof(object)), paramExpression);

                    switch (sortDirection)
                    {
                        case OrderDirection.Asc:
                            source = isFirst ? source.OrderBy(sortExpression) : ((IOrderedQueryable<TEntity>)source).ThenBy(sortExpression);
                            break;
                        case OrderDirection.Desc:
                            source = isFirst ? source.OrderByDescending(sortExpression) : ((IOrderedQueryable<TEntity>)source).ThenByDescending(sortExpression);
                            break;
                    }
                    isFirst = false;
                }
            }
            return source;
        }

        /// <summary>
        /// Asynchronously adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <param name="userId">The ID of the user who created the entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
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

        /// <summary>
        /// Asynchronously adds a range of new entities to the database.
        /// </summary>
        /// <param name="entities">The collection of entities to be added.</param>
        /// <param name="userId">The ID of the user who created the entities.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
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

        /// <summary>
        /// Asynchronously updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <param name="userId">The ID of the user who modified the entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
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

        /// <summary>
        /// Asynchronously updates a range of existing entities in the database.
        /// </summary>
        /// <param name="entities">The collection of entities to be updated.</param>
        /// <param name="userId">The ID of the user who modified the entities.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
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

        /// <summary>
        /// Asynchronously removes an existing entity from the database.
        /// </summary>
        /// <param name="entity">The entity to be removed.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        public async Task<int> RemoveAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously removes a range of existing entities from the database.
        /// </summary>
        /// <param name="entities">The collection of entities to be removed.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        public async Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously soft removes an existing entity from the database.
        /// </summary>
        /// <param name="entity">The entity to be removed.</param>
        /// <param name="userId">The ID of the user who modified the entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
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

        /// <summary>
        /// Asynchronously soft removes a range of existing entities from the database.
        /// </summary>
        /// <param name="entities">The collection of entities to be removed.</param>
        /// <param name="userId">The ID of the user who modified the entities.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
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

        /// <summary>
        /// Checks if an entity exists in the database by its primary key.
        /// </summary>
        /// <param name="keyValues">The primary key values of the entity.</param>
        /// <returns>True if the entity exists, false otherwise.</returns>
        public bool ExistsById(params object?[]? keyValues)
        {
            var entity = _context.Set<TEntity>().Find(keyValues);
            return entity != null;
        }
    }
}
