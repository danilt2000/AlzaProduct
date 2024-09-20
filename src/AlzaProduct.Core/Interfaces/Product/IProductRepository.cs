using AlzaProduct.Core.Interfaces.Persistent;

namespace AlzaProduct.Core.Interfaces.Product
{
    public interface IProductRepository : IRepository<IProduct>
    {
        IEnumerable<IProduct> GetListPagination(int pageNumber, int pageSize);
    }
}
