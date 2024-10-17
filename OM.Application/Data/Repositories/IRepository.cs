using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OM.Application.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Gets all objects from database
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllAsync();

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
        /// Delete the object from database.
        /// </summary>
        /// <param name="t">Specified a existing object to delete.</param>        
        Task<int> DeleteAsync(TEntity t);

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="id">Specified a existing id object to delete.</param>        
        Task<int> DeleteAsync(Guid id);

        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        Task<int> UpdateAsync(TEntity t);

        /// <summary>
        /// Update objects changes and save to database.
        /// </summary>
        /// <param name="entities">Specified the object to save.</param>
        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update objects changes and save to database.
        /// </summary>
        /// <param name="entities"></param>
        Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
