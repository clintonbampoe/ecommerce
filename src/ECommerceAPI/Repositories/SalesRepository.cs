using ECommerceAPI.Data;
using ECommerceAPI.Models;
using ECommerceAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories;

public class SalesRepository
{
    private readonly AppDbContext _dbContext;

    public SalesRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<ProductSale>> GetAllProductSales()
    {
        var allProductSales = await _dbContext.ProductSales.ToListAsync();
        return allProductSales;
    }

    public async Task<IEnumerable<ProductSaleDto>?> GetProductSalesByProductId(int productId)
    {
        // TODO: handle null reference in the services layer
        var productSales = await _dbContext.ProductSales
            .Where(ps => ps.ProductId == productId)
            .Select(ps => new ProductSaleDto()
            {
                ProductId = ps.ProductId,
                SalesId = ps.SalesId,
                ProductName = ps.Product.Name,
                TotalCost = ps.TotalCost
            }).ToListAsync();

        return productSales;
    }

    public async Task<IEnumerable<ProductSaleDto?>> GetProductSalesbySalesId(int salesId)
    {
        // TODO: handle null reference in services layer
        var productSales = await _dbContext.ProductSales
            .Where(ps => ps.SalesId == salesId)
            .Select(ps => new ProductSaleDto()
            {
                ProductId = ps.ProductId,
                SalesId = ps.SalesId,
                SaleDate = ps.Sale.SaleDate,
                TotalCost = ps.TotalCost
            }).ToListAsync();

        return productSales;
    }

    public async Task<IEnumerable<ProductSale>> CreateProductSale(SalesCreateDto dto)
    {
        var newSale = new Sale()
        {
            SaleDate = dto.SaleDate,

            ProductSales = dto.Items.Select(item => new ProductSale()
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
            }).ToList()
        };

        _dbContext.Sales.Add(newSale);
        await _dbContext.SaveChangesAsync();

        return await _dbContext.ProductSales
            .Where(ps => ps.SalesId == newSale.Id).ToListAsync();
    }
}