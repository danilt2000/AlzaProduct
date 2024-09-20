using AlzaProduct.Core.Interfaces.Product;

namespace AlzaProduct.Persistent.EF.Repositories;
internal class ProductRepository(AppDbContext appDbContext)//Todo add logger 
    : IProductRepository
{
    public IProduct GetById(string id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IProduct> GetList()
    {
        return appDbContext.Products.ToList();
    }

    public IEnumerable<IProduct> GetListPagination(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public void Save(IProduct item)
    {
        throw new NotImplementedException();
    }

    public void Update(string id, IProduct item)
    {
        throw new NotImplementedException();
    }

    public void Delete(string id)
    {
        throw new NotImplementedException();
    }
}
