using System.Linq.Expressions;

namespace OM.Application.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity? Find(params object?[]? keyValues);

        Task<TEntity?> FindAsync(params object?[]? keyValues);

        TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        List<TEntity> FindAll(bool ignoreDeleteFlg = false);

        /// <summary>
        /// Gets all objects from database
        /// </summary>
        Task<List<TEntity>> FindAllAsync(bool ignoreDeleteFlg = false);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Find object by Expression.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Create a new object to database.
        /// </summary>
        /// <param name="t">Specified a new object to create.</param>
        Task<int> AddAsync(TEntity t);

        /// <summary>
        /// Update objects changes and save to database.
        /// </summary>
        /// <param name="entities">Specified the object to save.</param>
        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        Task<int> UpdateAsync(TEntity t);

        /// <summary>
        /// Update objects changes and save to database.
        /// </summary>
        /// <param name="entities"></param>
        Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="t">Specified a existing object to delete.</param>        
        Task<int> RemoveAsync(TEntity t);

        Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);

        Task<int> SoftRemoveAsync(TEntity entity);

        Task<int> SoftRemoveRangeAsync(IEnumerable<TEntity> entities);

        bool ExistsById(params object?[]? keyValues);
    }
}
