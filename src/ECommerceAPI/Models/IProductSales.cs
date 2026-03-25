namespace ECommerceAPI.Models;

public interface IProductSales
{
    public int ProductId { get; set; }
    public IProduct Product { get; set; }
    
    public int SalesId { get; set; }
    public ISale Sale { get; set; }
    
    public int Quantity { get; set; }
}