namespace ECommerceAPI.Models.Dtos;

public class SalesCreateDto
{
    public DateTime SaleDate { get; set; }
    public List<ProductItem> Items { get; set; } = [];
}