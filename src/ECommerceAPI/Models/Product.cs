using System.ComponentModel.DataAnnotations;
using ECommerceAPI.Models.Dtos;

namespace ECommerceAPI.Models;

public class Product
{
    public int Id { get; set; }
    [MaxLength(64)] public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public int QuantityInStock { get; set; }
    public DateTime DateAdded { get; set; }
    
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<ProductSale> ProductSales { get; set; } = [];

    public Product()
    {
        
    }

    public Product(ProductDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Price = dto.Price;
        QuantityInStock = dto.QuantityInStock;
        CategoryId = dto.CategoryId;
    }
}