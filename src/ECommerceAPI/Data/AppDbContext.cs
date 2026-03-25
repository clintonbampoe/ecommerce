using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductSale> ProductSales { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // composite key for IProductSale
        modelBuilder.Entity<IProductSale>()
            .HasKey(ps => new { ps.ProductId, ps.SalesId });
        
        // many-to-many : Product side
        modelBuilder.Entity<IProductSale>()
            .HasOne(ps => ps.Product)
            .WithMany(p => p.ProductSales)
            .HasForeignKey(ps => ps.ProductId);
        
        // many-to-many : Sale side
        modelBuilder.Entity<IProductSale>()
            .HasOne(ps => ps.Sale)
            .WithMany(s => s.ProductSales)
            .HasForeignKey(ps => ps.Sale);
        
        // one-to-many : mapping ICategory and IProduct
        modelBuilder.Entity<IProduct>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);
    }
}