using Microsoft.EntityFrameworkCore;
using Onion.Library.Domain.Feat_Product.Entities;

namespace Onion.Library.SPI.Persistence
{
    public class RepositoryDbContext: DbContext
    {
        public RepositoryDbContext(DbContextOptions options): base(options) { }

        public DbSet<Product> Products { get; set; }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
            modelBuilder.HasDefaultSchema(Schema.ProductData);
        }
    }
}
