using ECommerceAPI.Models.Dtos;
using ECommerceAPI.Repositories;

namespace ECommerceAPI.Services;

public class SaleService : ISaleService
{
    private readonly SalesRepository _repository;

    public SaleService(SalesRepository repository)
    {
        _repository = repository;
    }

    /*
     * NOTE
     * In this class, methods that return nullable lists are like that by design.
     * If the return list a method gets from the repository class is nullable or empty, the method returns an empty list instead of a null reference.
     * The controller is supposed to handle this gracefully.
     * That is: it should print a meaningful message if it receives an empty list and the normal response if otherwise
     */

    public async Task<IEnumerable<ProductSaleDto>?> GetByProductId(int productId)
    {
        var sales = await _repository.GetProductSalesByProductId(productId);

        if (sales is null)
        {
            return [];
        }

        return sales.Select(sale => new ProductSaleDto(sale));
    }

    public async Task<IEnumerable<ProductSaleDto>?> GetBySaleId(int salesId)
    {
        var sales = await _repository.GetProductSalesBySalesId(salesId);

        if (sales is null)
        {
            return [];
        }

        return sales.Select(sale => new ProductSaleDto(sale));
    }

    public async Task<IEnumerable<ProductSaleDto>?> GetAll()
    {
        var allSales = await _repository.GetAllProductSales();
        return allSales.Select(sale => new ProductSaleDto(sale));
    }

    public async Task<IEnumerable<ProductSaleDto>> PostNewEntry(SalesCreateDto dto)
    {
        var entries = await _repository.CreateProductSale(dto);

        if (entries is null)
        {
            return [];
        }

        return entries.Select(entry => new ProductSaleDto(entry));
    }
}