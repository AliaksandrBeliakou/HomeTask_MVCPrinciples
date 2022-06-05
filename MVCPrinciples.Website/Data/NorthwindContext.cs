using Microsoft.EntityFrameworkCore;
using MVCPrinciples.Website.Data.Entities;

namespace MVCPrinciples.Website.Data
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId).HasName("ProductID");
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId).HasName("CategoryID");
            modelBuilder.Entity<Supplier>().HasKey(c => c.SupplierId).HasName("SupplierID");

            modelBuilder.Entity<Product>()
                .HasOne(a => a.Category)
                .WithMany();
            modelBuilder.Entity<Product>()
                .HasOne(a => a.Supplier);
        }

    }
}
