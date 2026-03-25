namespace ECommerceAPI.Models;

public interface ISale
{
    public int Id { get; set; }
    public double TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    
    public ICollection<IProductSales> ProductSales { get; set; }
}