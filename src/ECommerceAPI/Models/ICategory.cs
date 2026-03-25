using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models;

public interface ICategory
{
    public int Id { get; set; }
    [MaxLength(32)] public string Name { get; set; }
}