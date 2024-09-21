using AlzaProduct.Persistent.EF.SeedData;
using AlzaProduct.Persistent.EF.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AlzaProduct.Persistent.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public IConfiguration Config { get; set; } = null!;

        public AppDbContext(IConfiguration config)
        {
            Config = config;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.GetConnectionString("SqlConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedProducts();
        }
    }
}
