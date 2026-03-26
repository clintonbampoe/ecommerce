namespace ECommerceAPI.Models;

public class ProductSale
{
    public int ProductId { get; set; }
    public required Product Product { get; set; }
    
    public int SalesId { get; set; }
    public required Sale Sale { get; set; }
    
    public int Quantity { get; set; }
}