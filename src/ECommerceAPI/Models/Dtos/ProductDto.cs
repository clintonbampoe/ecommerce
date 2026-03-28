namespace ECommerceAPI.Models.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public int QuantityInStock { get; set; }
    public int CategoryId { get; set; }
    
    public ProductDto()
    {
        
    }

    public ProductDto(Product product)
    {
        Id = product.Id;
        Name = product.Name;
        Price = product.Price;
        QuantityInStock = product.QuantityInStock;
        CategoryId = product.CategoryId;
    }
}