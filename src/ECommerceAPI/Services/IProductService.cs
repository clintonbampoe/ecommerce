using ECommerceAPI.Models;

namespace ECommerceAPI.Services;

public interface IProductService
{
    Task<IEnumerable<Product?>> GetAllProducts();
    Task<Product?> GetProductById(int productId);
    Task<Product> CreateProduct(Product product);
}