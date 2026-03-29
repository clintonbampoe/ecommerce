using System.ComponentModel.DataAnnotations;
using ECommerceAPI.Models.Dto;

namespace ECommerceAPI.Models;

public class Category
{
    public int Id { get; set; }
    [MaxLength(32)] public string Name { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = [];

    public Category()
    {
        
    }
    
    public Category(CategoryDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
    }
}