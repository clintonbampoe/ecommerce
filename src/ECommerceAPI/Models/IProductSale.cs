namespace ECommerceAPI.Models;

public interface IProductSale
{
    public int ProductId { get; set; }
    public IProduct Product { get; set; }
    
    public int SalesId { get; set; }
    public ISale Sale { get; set; }
    
    public int Quantity { get; set; }
    public decimal AppliedPrice { get; set; }
}