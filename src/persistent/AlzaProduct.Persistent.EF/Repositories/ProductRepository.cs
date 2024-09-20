using AlzaProduct.Core.Interfaces.Product;
using AlzaProduct.Persistent.EF.Tables;

namespace AlzaProduct.Persistent.EF.Repositories;
internal class ProductRepository(AppDbContext appDbContext)
    : IProductRepository
{
    public IProduct GetById(int id)
    {
        return appDbContext.Products.First(x => x.Id == id);
    }

    public IEnumerable<IProduct> GetList()
    {
        return appDbContext.Products.ToList();
    }

    public IEnumerable<IProduct> GetListPagination(int pageNumber, int pageSize)
    {
        return appDbContext.Products
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public void Save(IProduct product)
    {
        var productDb = new Product
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            ImgUri = product.ImgUri,
            Description = product.Description
        };

        appDbContext.Products.Add(productDb);

        appDbContext.SaveChanges();
    }

    public void Update(int id, IProduct item)
    {
        var existingProduct = appDbContext.Products.FirstOrDefault(x => x.Id == id);

        if (existingProduct != null)
        {
            existingProduct.Name = item.Name;
            existingProduct.Price = item.Price;
            existingProduct.ImgUri = item.ImgUri;
            existingProduct.Description = item.Description;

            appDbContext.Products.Update(existingProduct);
            appDbContext.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException($"Product with ID {id} not found.");
        }
    }

    public void Delete(int id)
    {
        var product = appDbContext.Products.FirstOrDefault(x => x.Id == id);

        if (product != null)
        {
            appDbContext.Products.Remove(product);
            appDbContext.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException($"Product with ID {id} not found.");
        }
    }
}
