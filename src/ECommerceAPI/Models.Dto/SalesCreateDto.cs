namespace ECommerceAPI.Models.Dto;

public class SalesCreateDto
{
    public DateTime SaleDate { get; set; }
    public List<ProductItem> Items { get; set; } = [];
}