namespace ECommerceAPI.Models;

public class ProductSale
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    
    public int SalesId { get; set; }
    public Sale? Sale { get; set; }
    
    public int Quantity { get; set; }
    public int TotalCost { get; set; }
}