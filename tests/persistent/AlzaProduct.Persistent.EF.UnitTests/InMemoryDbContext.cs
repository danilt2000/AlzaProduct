using Microsoft.EntityFrameworkCore;

namespace AlzaProduct.Persistent.EF.UnitTests;
internal class InMemoryDbContext
{
    internal static AppDbContext GetDb(string dbName)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        var context = new AppDbContext(options);
        return context;
    }
}
