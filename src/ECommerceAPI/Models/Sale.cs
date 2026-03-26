namespace ECommerceAPI.Models;

public class Sale
{
    public int Id { get; set; }
    public double TotalAmount { get; set; }
    public DateTime SaleDate { get; set; } = DateTime.Now;

    public ICollection<ProductSale> ProductSales { get; set; } = [];
}