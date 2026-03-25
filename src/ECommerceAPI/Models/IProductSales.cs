namespace ECommerceAPI.Models;

public interface IProductSales
{
    public int ProductId { get; set; }
    public int SalesId { get; set; }
    public int Quantity { get; set; }
}