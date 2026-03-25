namespace ECommerceAPI.Models;

public class ProductSales : IProductSales
{
    public int ProductId { get; set; }
    public int SalesId { get; set; }
    public int Quantity { get; set; }
}