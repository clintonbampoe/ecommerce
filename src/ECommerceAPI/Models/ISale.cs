namespace ECommerceAPI.Models;

public interface ISale
{
    public int Id { get; set; }
    public double TotalAmount { get; set; }
    public DateTime SaleDate { get; set; }
    
    public ICollection<IProductSale> ProductSales { get; set; }
}