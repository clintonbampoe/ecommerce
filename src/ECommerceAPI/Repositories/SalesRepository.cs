using ECommerceAPI.Data;
using ECommerceAPI.Models;
using ECommerceAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories;

public class SalesRepository
{
    private readonly AppDbContext _dbContext;

    public SalesRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    /*
     * NOTE
     * The ProductSale table is accessed from the SalesRepository.
     * This is because every time a Sale object is created in the db, a ProductSale object is created immediately.
     * Hence, ProductSale is mainly dependent on Sale so it did not make sense to make its own repo and service.
     * Also, the client should only interact with the Sale service.
     * This is also to make the SaleRepository the only point of entry and exit for the ProductSale table
     * Due to all these reasons, the ProductSale table and its operations are accessed from this class.
     */
    
    public async Task<IEnumerable<ProductSale>> GetAllProductSales()
    {
        var allProductSales = await _dbContext.ProductSales.ToListAsync();
        return allProductSales;
        
    }

    public async Task<IEnumerable<ProductSale>?> GetProductSalesByProductId(int productId)
    {
        var productSales = await _dbContext.ProductSales.ToListAsync();
        return productSales;
    }

    public async Task<IEnumerable<ProductSale>?> GetProductSalesBySalesId(int salesId)
    {
        var productSales = await _dbContext.ProductSales.ToListAsync();
        return productSales;
    }
    
    public async Task<IEnumerable<ProductSale>?> CreateProductSale(SalesCreateDto dto)
    {
        var newSale = new Sale()
        {
            SaleDate = dto.SaleDate,

            ProductSales = dto.Items.Select(item => new ProductSale()
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity
            }).ToList()
        };

        _dbContext.Sales.Add(newSale);
        await _dbContext.SaveChangesAsync();

        
        return await _dbContext.ProductSales.ToListAsync();
    }
}