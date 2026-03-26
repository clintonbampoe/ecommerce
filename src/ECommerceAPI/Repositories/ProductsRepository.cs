using ECommerceAPI.Data;
using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories;

public class ProductsRepository
{
    private readonly AppDbContext _dbContext;

    public ProductsRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<Product>?> GetAllProducts()
    {
        var allProducts = await _dbContext.Products.ToListAsync();
        return allProducts;
    }

    public async Task<Product> CreateProduct(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> GetProductById(int productId)
    {
        var product = await _dbContext.Products.FindAsync(productId);
        return product;
    }
}