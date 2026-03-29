using ECommerceAPI.Data;
using ECommerceAPI.Models;
using ECommerceAPI.Models.Dto;
using ECommerceAPI.Models.Pagination;
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
    
    public async Task<PagedResponse<ProductSale>> GetAllProductSales(PaginationParams paginationParams)
    {
        var totalRecords = await _dbContext.ProductSales
            .CountAsync();

        var productSales = await _dbContext.ProductSales
            .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
            .Take(paginationParams.PageSize)
            .ToListAsync();
        
        return new PagedResponse<ProductSale>(productSales, paginationParams.PageNumber, paginationParams.PageSize, totalRecords);
        
    }

    public async Task<PagedResponse<ProductSale>> GetProductSalesByProductId(int productId, PaginationParams paginationParams)
    {
        var totalRecords = await _dbContext.ProductSales
            .Where(p => p.ProductId == productId)
            .CountAsync();

        var productSalesByProductId = await _dbContext.ProductSales
            .AsNoTracking()
            .Where(ps => ps.ProductId == productId)
            .OrderBy(ps => ps.ProductId)
            .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
            .Take(paginationParams.PageSize)
            .ToListAsync();

        var response = new PagedResponse<ProductSale>(productSalesByProductId, paginationParams.PageNumber,
            paginationParams.PageSize, totalRecords);
        return response;
    }

    public async Task<PagedResponse<ProductSale>> GetProductSalesBySalesId(int salesId, PaginationParams paginationParams)
    {
        var totalRecords = await _dbContext.ProductSales
            .Where(ps => ps.SalesId == salesId)
            .CountAsync();

        var productSalesBySalesId = await _dbContext.ProductSales
            .AsNoTracking()
            .Where(ps => ps.SalesId == salesId)
            .OrderBy(ps => ps.SalesId)
            .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
            .Take(paginationParams.PageSize)
            .ToListAsync();

        var response = new PagedResponse<ProductSale>(productSalesBySalesId, paginationParams.PageNumber,
            paginationParams.PageSize, totalRecords);
        return response;
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