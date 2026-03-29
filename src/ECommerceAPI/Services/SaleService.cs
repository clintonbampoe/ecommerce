using ECommerceAPI.Models;
using ECommerceAPI.Models.Dto;
using ECommerceAPI.Models.Pagination;
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

    public async Task<PagedResponse<ProductSaleDto>> GetByProductId(int productId, PaginationParams paginationParams)
    {
        var sales = await _repository.GetProductSalesByProductId(productId, paginationParams);

        return ConvertRawObjectsFromPagedResponseToDto(sales);
    }

    public async Task<PagedResponse<ProductSaleDto>> GetBySaleId(int salesId, PaginationParams paginationParams)
    {
        var sales = await _repository.GetProductSalesBySalesId(salesId, paginationParams);

        return ConvertRawObjectsFromPagedResponseToDto(sales);
    }

    public async Task<PagedResponse<ProductSaleDto>> GetAll(PaginationParams paginationParams)
    {
        var sales = await _repository.GetAllProductSales(paginationParams);

        return ConvertRawObjectsFromPagedResponseToDto(sales);
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

    private PagedResponse<ProductSaleDto> ConvertRawObjectsFromPagedResponseToDto(PagedResponse<ProductSale> sales)
    {
        var dtos = sales.Data
            .Select(ps => new ProductSaleDto(ps))
            .ToList();

        return new PagedResponse<ProductSaleDto>(dtos, sales.PageNumber, sales.PageSize, sales.TotalRecords);
    }
}