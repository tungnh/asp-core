using OM.Application.Models.Paging;
using System.Linq.Expressions;

namespace OM.Application.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> FindAsync(params object?[]? keyValues);

        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Gets all objects from database
        /// </summary>
        Task<List<TEntity>> FindAllAsync(bool ignoreDeleteFlg = false);

        Task<List<TEntity>> FindAllAsync(string[]? sort, bool ignoreDeleteFlg = false);

        /// <summary>
        /// Find object by Expression.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, bool ignoreDeleteFlg = false);

        Task<PaginatedList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, Pageable pageable, bool ignoreDeleteFlg = false);
        
        Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, string[]? sort, bool ignoreDeleteFlg = false);

        /// <summary>
        /// Create a new object to database.
        /// </summary>
        /// <param name="t">Specified a new object to create.</param>
        Task<int> AddAsync(TEntity t, string userId);

        /// <summary>
        /// Update objects changes and save to database.
        /// </summary>
        /// <param name="entities">Specified the object to save.</param>
        Task<int> AddRangeAsync(IEnumerable<TEntity> entities, string userId);

        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        Task<int> UpdateAsync(TEntity t, string? userId = null);

        /// <summary>
        /// Update objects changes and save to database.
        /// </summary>
        /// <param name="entities"></param>
        Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities, string? userId = null);

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="t">Specified a existing object to delete.</param>        
        Task<int> RemoveAsync(TEntity t);

        Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);

        Task<int> SoftRemoveAsync(TEntity entity, string? userId = null);

        Task<int> SoftRemoveRangeAsync(IEnumerable<TEntity> entities, string? userId = null);

        bool ExistsById(params object?[]? keyValues);
    }
}
