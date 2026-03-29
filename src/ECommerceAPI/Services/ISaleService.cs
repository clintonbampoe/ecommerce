using ECommerceAPI.Models.Dto;
using ECommerceAPI.Models.Pagination;

namespace ECommerceAPI.Services;

public interface ISaleService
{
    Task<PagedResponse<ProductSaleDto>> GetAll(PaginationParams paginationParams);
    Task<PagedResponse<ProductSaleDto>> GetByProductId(int productId, PaginationParams paginationParams);
    Task<PagedResponse<ProductSaleDto>> GetBySaleId(int saleId, PaginationParams paginationParams);
    Task<IEnumerable<ProductSaleDto>> PostNewEntry(SalesCreateDto dto);
}