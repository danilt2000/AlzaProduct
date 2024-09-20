namespace AlzaProduct.Core.Interfaces.Persistent;

/// <summary>
/// Generic repository interface for basic data operations.
/// Provides CRUD operations for the specified type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of entity that the repository handles.</typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>The entity with the specified id, or null if not found.</returns>
    T GetById(int id);

    /// <summary>
    /// Retrieves all entities from the repository.
    /// </summary>
    /// <returns>A collection of all entities.</returns>
    IEnumerable<T> GetList();

    /// <summary>
    /// Saves a new entity to the repository.
    /// </summary>
    /// <param name="item">The entity to save.</param>
    void Save(T item);

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to update.</param>
    /// <param name="item">The updated entity object.</param>
    void Update(int id, T item);

    /// <summary>
    /// Deletes an entity from the repository by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    void Delete(int id);
}
