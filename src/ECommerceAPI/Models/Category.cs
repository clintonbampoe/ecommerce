using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models;

public class Category : ICategory
{
    public int Id { get; set; }
    [MaxLength(32)] public string Name { get; set; } = string.Empty;
    public ICollection<IProduct> Products { get; set; }
}