namespace ECommerceAPI.Models;

public class ProductSale : IProductSale
{
    public int ProductId { get; set; }
    public required IProduct Product { get; set; }
    
    public int SalesId { get; set; }
    public required ISale Sale { get; set; }
    
    public int Quantity { get; set; }
}