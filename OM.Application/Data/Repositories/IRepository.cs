using OM.Application.Models.Paging;
using System.Linq.Expressions;

namespace OM.Application.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Asynchronously finds an entity with the given key values.
        /// </summary>
        /// <param name="keyValues">The values of the primary key for the entity to be found.</param>
        /// <returns>A task that represents the asynchronous find operation. The task result contains the entity found, or the default value of TEntity if no entity is found.</returns>
        Task<TEntity?> FindAsync(params object?[]? keyValues);

        /// <summary>
        /// Asynchronously finds the first entity that matches the given predicate.
        /// </summary>
        /// <param name="predicate">A function to test each entity for a condition.</param>
        /// <returns>The first entity that matches the predicate, or the default value of TEntity if no entity matches.</returns>
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Asynchronously retrieves a list of all entities of type TEntity.
        /// </summary>
        /// <param name="ignoreDeleteFlg">Optional flag to ignore the deletion flag of entities. Defaults to false.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of TEntity objects.</returns>
        Task<List<TEntity>> FindAllAsync(bool ignoreDeleteFlg = false);

        /// <summary>
        /// Asynchronously retrieves a list of all entities of type TEntity, 
        /// sorted according to the provided sort parameters.
        /// </summary>
        /// <param name="sort">An array of strings representing the sort parameters.</param>
        /// <param name="ignoreDeleteFlg">Optional flag to ignore the deletion flag of entities. Defaults to false.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of TEntity objects.</returns>
        Task<List<TEntity>> FindAllAsync(string[]? sort, bool ignoreDeleteFlg = false);

        /// <summary>
        /// Asynchronously retrieves a list of entities of type TEntity that match the given predicate.
        /// </summary>
        /// <param name="predicate">A function to test each entity in the set for a condition.</param>
        /// <param name="ignoreDeleteFlg">Optional flag to ignore the deletion flag of entities. Defaults to false.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of TEntity objects.</returns>
        Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, bool ignoreDeleteFlg = false);

        /// <summary>
        /// Asynchronously retrieves a list of entities of type TEntity that match the given predicate, 
        /// sorted according to the provided pageable parameters, and paginated.
        /// </summary>
        /// <param name="predicate">A function to test each entity in the set for a condition.</param>
        /// <param name="pageable">An object containing pagination and sorting parameters.</param>
        /// <param name="ignoreDeleteFlg">Optional flag to ignore the deletion flag of entities. Defaults to false.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a PaginatedList of TEntity objects.</returns>
        Task<PaginatedList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, Pageable pageable, bool ignoreDeleteFlg = false);

        /// <summary>
        /// Asynchronously retrieves a list of entities of type TEntity that match the given predicate, 
        /// sorted according to the provided sort parameters.
        /// </summary>
        /// <param name="predicate">A function to test each entity in the set for a condition.</param>
        /// <param name="sort">An array of strings representing the sort parameters.</param>
        /// <param name="ignoreDeleteFlg">Optional flag to ignore the deletion flag of entities. Defaults to false.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of TEntity objects.</returns>
        Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, string[]? sort, bool ignoreDeleteFlg = false);

        /// <summary>
        /// Asynchronously adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <param name="userId">The ID of the user who created the entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> AddAsync(TEntity t, string userId);

        /// <summary>
        /// Asynchronously adds a range of new entities to the database.
        /// </summary>
        /// <param name="entities">The collection of entities to be added.</param>
        /// <param name="userId">The ID of the user who created the entities.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> AddRangeAsync(IEnumerable<TEntity> entities, string userId);

        /// <summary>
        /// Asynchronously updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <param name="userId">The ID of the user who modified the entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> UpdateAsync(TEntity t, string? userId = null);

        /// <summary>
        /// Asynchronously updates a range of existing entities in the database.
        /// </summary>
        /// <param name="entities">The collection of entities to be updated.</param>
        /// <param name="userId">The ID of the user who modified the entities.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities, string? userId = null);

        /// <summary>
        /// Asynchronously removes an existing entity from the database.
        /// </summary>
        /// <param name="entity">The entity to be removed.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>      
        Task<int> RemoveAsync(TEntity t);

        /// <summary>
        /// Asynchronously removes a range of existing entities from the database.
        /// </summary>
        /// <param name="entities">The collection of entities to be removed.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Asynchronously soft removes an existing entity from the database.
        /// </summary>
        /// <param name="entity">The entity to be removed.</param>
        /// <param name="userId">The ID of the user who modified the entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> SoftRemoveAsync(TEntity entity, string? userId = null);

        /// <summary>
        /// Asynchronously soft removes a range of existing entities from the database.
        /// </summary>
        /// <param name="entities">The collection of entities to be removed.</param>
        /// <param name="userId">The ID of the user who modified the entities.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> SoftRemoveRangeAsync(IEnumerable<TEntity> entities, string? userId = null);

        /// <summary>
        /// Asynchronously checks if an entity with the specified key values exists in the database.
        /// </summary>
        /// <param name="keyValues">The key values of the entity to check.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the entity exists.</returns>
        bool ExistsById(params object?[]? keyValues);
    }
}
