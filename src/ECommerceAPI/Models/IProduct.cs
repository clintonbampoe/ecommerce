namespace ECommerceAPI.Models;

public interface IProduct
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }
    public DateTime DateAdded { get; set; }
}