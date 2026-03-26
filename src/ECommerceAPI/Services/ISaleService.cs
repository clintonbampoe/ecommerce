using ECommerceAPI.Models.Dtos;

namespace ECommerceAPI.Services;

public interface ISaleService
{
    Task<IEnumerable<ProductSaleDto>?> GetByProductId(int productId);
    Task<IEnumerable<ProductSaleDto>?> GetBySaleId(int saleId);
    Task<IEnumerable<ProductSaleDto>?> GetAll();
    Task<IEnumerable<ProductSaleDto>> PostNewEntry(SalesCreateDto dto);
}