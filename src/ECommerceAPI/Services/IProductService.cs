using ECommerceAPI.Models;
using ECommerceAPI.Models.Dtos;

namespace ECommerceAPI.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto?>> GetAllProducts();
    Task<ProductDto?> GetProductById(int productId);
    Task<ProductDto> CreateProduct(ProductDto product);
}