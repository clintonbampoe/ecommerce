namespace ECommerceAPI.Models.Dtos;

public class ProductSaleDto
{
    public int ProductId { get; set; }
    public int SalesId { get; set; }
    
    public int Quantity { get; set; }
    public decimal TotalCost { get; set; }

    public string ProductName { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
}