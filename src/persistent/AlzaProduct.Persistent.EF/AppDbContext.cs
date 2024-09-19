using AlzaProduct.Persistent.EF.Database.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AlzaProduct.Persistent.EF;

public class AppDbContext(IConfiguration config) : DbContext
{
    public DbSet<Product> Products { get; set; }

    public IConfiguration Config { get; set; } = config;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Config.GetConnectionString("SqlConnection"));
    }
}
