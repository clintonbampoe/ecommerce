using ECommerceAPI.Models;
using ECommerceAPI.Models.Dto;
using ECommerceAPI.Repositories;

namespace ECommerceAPI.Services;

public class ProductService : IProductService
{
    private readonly ProductsRepository _repository;

    public ProductService(ProductsRepository repository)
    {
        _repository = repository;
    }
    
    /*
     * NOTE
     * In this class, methods that return nullable objects are like that by design.
     * If the return object a method gets from the repository class is nullable or empty, the method returns a null object.
     * The controller is supposed to handle this gracefully.
     * That is: it should print a meaningful message if it receives an empty list and the normal response if otherwise
     */
    
    
    public async Task<IEnumerable<ProductDto?>> GetAllProducts()
    {
        var allProducts = await _repository.GetAllProducts();

        if (allProducts is null)
        {
            return [];
        }
        
        return allProducts.Select(product => new ProductDto(product));
    }

    public async Task<ProductDto?> GetProductById(int productId)
    {
        var product = await _repository.GetProductById(productId);

        if (product is null)
        {
            return null;
        }

        return new ProductDto(product);
    }
    
    public async Task<ProductDto> CreateProduct(ProductDto product)
    {
        await _repository.CreateProduct(new Product(product));
        return new ProductDto(new Product(product));
    }
}