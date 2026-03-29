using ECommerceAPI.Data;
using ECommerceAPI.Models;
using ECommerceAPI.Models.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories;

public class ProductsRepository
{
    private readonly AppDbContext _dbContext;

    public ProductsRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<PagedResponse<Product>> GetAllProducts(PaginationParams paginationParams)
    {
        var totalRecords = await _dbContext.Products.CountAsync();
        var products = await _dbContext.Products.Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
            .Take(paginationParams.PageSize)
            .ToListAsync();

        return new PagedResponse<Product>(products, paginationParams.PageNumber, paginationParams.PageSize,
            totalRecords);
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