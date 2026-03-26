using ECommerceAPI.Models;
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
    
    
    public async Task<IEnumerable<Product?>> GetAllProducts()
    {
        var allProducts = await _repository.GetAllProducts();

        if (allProducts is null)
        {
            return [];
        }

        return allProducts;
    }

    public async Task<Product?> GetProductById(int productId)
    {
        var product = await _repository.GetProductById(productId);

        if (product is null)
        {
            return null;
        }

        return product;
    }
    
    public async Task<Product> CreateProduct(Product product)
    {
        await _repository.CreateProduct(product);
        return product;
    }
}