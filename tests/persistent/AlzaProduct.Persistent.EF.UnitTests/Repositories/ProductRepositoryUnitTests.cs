using AlzaProduct.Core.Interfaces.Product;
using AlzaProduct.Persistent.EF.Repositories;
using AlzaProduct.Persistent.EF.Tables;
using Xunit;

namespace AlzaProduct.Persistent.EF.UnitTests.Repositories
{
    [Trait("Category", "UnitTest")]
    public class ProductRepositoryUnitTests
    {
        [Fact]
        public void GetById_Returns_Product_When_Found()
        {
            var context = InMemoryDbContext.GetDb(nameof(GetById_Returns_Product_When_Found));
            var product = new Product { Id = 1, Name = "Test Product", ImgUri = "Test ImgUri", Price = 12M };

            context.Products.Add(product);
            context.SaveChanges();

            var repository = new ProductRepository(context);

            var result = repository.GetById(1);

            Assert.Equal(product.Id, result.Id);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.ImgUri, result.ImgUri);
            Assert.Equal(product.Price, result.Price);
        }

        [Fact]
        public void GetById_Returns_Null_When_Not_Found()
        {
            var context = InMemoryDbContext.GetDb(nameof(GetById_Returns_Null_When_Not_Found));

            var repository = new ProductRepository(context);

            Assert.Throws<InvalidOperationException>(() => repository.Save(repository.GetById(999)));
        }

        [Fact]
        public void GetList_Returns_All_Products()
        {
            var context = InMemoryDbContext.GetDb(nameof(GetList_Returns_All_Products));
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", ImgUri = "img1.jpg", Price = 10M },
                new Product { Id = 2, Name = "Product 2", ImgUri = "img2.jpg", Price = 20M }
            };
            context.Products.AddRange(products);
            context.SaveChanges();

            var repository = new ProductRepository(context);

            var result = repository.GetList();

            var collection = result as IProduct[] ?? result.ToArray();
            Assert.Equal(products.Count, collection.Length);
            foreach (var product in products)
            {
                Assert.Contains(collection, p => p.Id == product.Id);
            }
        }

        [Fact]
        public void GetList_Returns_Empty_List_When_No_Products()
        {
            var context = InMemoryDbContext.GetDb(nameof(GetList_Returns_Empty_List_When_No_Products));

            var repository = new ProductRepository(context);

            var result = repository.GetList();

            Assert.Empty(result);
        }

        [Fact]
        public void GetListPagination_Returns_Paginated_Products()
        {
            var context = InMemoryDbContext.GetDb(nameof(GetListPagination_Returns_Paginated_Products));
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", ImgUri = "img1.jpg", Price = 10M },
                new Product { Id = 2, Name = "Product 2", ImgUri = "img2.jpg", Price = 20M },
                new Product { Id = 3, Name = "Product 3", ImgUri = "img3.jpg", Price = 30M }
            };

            context.Products.AddRange(products);
            context.SaveChanges();

            var repository = new ProductRepository(context);

            var result = repository.GetListPagination(1, 2);

            Assert.Equal(products.Take(2), result);
        }

        [Fact]
        public void GetListPagination_Returns_Empty_List_When_No_Products()
        {
            var context = InMemoryDbContext.GetDb(nameof(GetListPagination_Returns_Empty_List_When_No_Products));

            var repository = new ProductRepository(context);

            var result = repository.GetListPagination(1, 2);

            Assert.Empty(result);
        }

        [Fact]
        public void Save_Adds_New_Product()
        {
            var context = InMemoryDbContext.GetDb(nameof(Save_Adds_New_Product));
            var repository = new ProductRepository(context);
            var product = new Product { Id = 1, Name = "Test Product", ImgUri = "Test ImgUri", Price = 12M };

            repository.Save(product);

            Assert.Equal(1, context.Products.Count());

            var savedProduct = context.Products.First();

            Assert.Equal(product.Id, savedProduct.Id);
            Assert.Equal(product.Name, savedProduct.Name);
            Assert.Equal(product.ImgUri, savedProduct.ImgUri);
            Assert.Equal(product.Price, savedProduct.Price);
        }

        [Fact]
        public void Update_Updates_Existing_Product()
        {
            var context = InMemoryDbContext.GetDb(nameof(Update_Updates_Existing_Product));
            var product = new Product { Id = 1, Name = "Test Product", ImgUri = "Test ImgUri", Price = 12M };
            context.Products.Add(product);
            context.SaveChanges();

            var repository = new ProductRepository(context);
            var updatedProduct = new Product { Id = 1, Name = "Updated Product", ImgUri = "Updated ImgUri", Price = 15M };

            repository.Update(1, updatedProduct);

            var result = context.Products.First();
            Assert.Equal("Updated Product", result.Name);
            Assert.Equal("Updated ImgUri", result.ImgUri);
            Assert.Equal(15M, result.Price);
        }

        [Fact]
        public void Update_Throws_Exception_When_Product_Not_Found()
        {
            var context = InMemoryDbContext.GetDb(nameof(Update_Throws_Exception_When_Product_Not_Found));
            var repository = new ProductRepository(context);
            var updatedProduct = new Product { Id = 1, Name = "Updated Product", ImgUri = "Updated ImgUri", Price = 15M };

            Assert.Throws<KeyNotFoundException>(() => repository.Update(999, updatedProduct));
        }

        [Fact]
        public void Delete_Removes_Existing_Product()
        {
            var context = InMemoryDbContext.GetDb(nameof(Delete_Removes_Existing_Product));
            var product = new Product { Id = 1, Name = "Test Product", ImgUri = "Test ImgUri", Price = 12M };
            context.Products.Add(product);
            context.SaveChanges();

            var repository = new ProductRepository(context);

            repository.Delete(1);

            Assert.Empty(context.Products);
        }

        [Fact]
        public void Delete_Throws_Exception_When_Product_Not_Found()
        {
            var context = InMemoryDbContext.GetDb(nameof(Delete_Throws_Exception_When_Product_Not_Found));

            var repository = new ProductRepository(context);

            Assert.Throws<KeyNotFoundException>(() => repository.Delete(999));
        }
    }
}
