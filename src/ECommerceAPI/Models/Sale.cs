namespace ECommerceAPI.Models;

public class Sale : ISale
{
    public int Id { get; set; }
    public double TotalAmount { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;

    public ICollection<IProductSale> ProductSales { get; set; } = [];
}