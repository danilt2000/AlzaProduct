using AlzaProduct.Core.Interfaces.Persistent;

namespace AlzaProduct.Core.Interfaces.Product
{
    /// <summary>
    /// Repository for handling product-specific data operations.
    /// Extends the base repository interface <see cref="IRepository{T}"/>.
    /// </summary>
    public interface IProductRepository : IRepository<IProduct>
    {
        /// <summary>
        /// Retrieves a paginated list of products.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve (starting from 1).</param>
        /// <param name="pageSize">The number of products per page.</param>
        /// <returns>A collection of products for the specified page.</returns>
        IEnumerable<IProduct> GetListPagination(int pageNumber, int pageSize);
    }
}
