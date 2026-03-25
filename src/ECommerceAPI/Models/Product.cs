using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models;

public class Product : IProduct
{
    public int Id { get; set; }
    [MaxLength(64)] public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public int QuantityInStock { get; set; }
    public DateTime DateAdded { get; set; }
    
    public int CategoryId { get; set; }
    public ICategory Category { get; set; }

    public ICollection<IProductSale> ProductSales { get; set; } = [];
}