using ECommerceAPI.Models.Dtos;

namespace ECommerceAPI.Models;

public class ProductSale
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    
    public int SalesId { get; set; }
    public Sale? Sale { get; set; }
    
    public int Quantity { get; set; }
    public double TotalCost { get; set; }
    public DateTime SaleDate { get; set; }

    public ProductSale()
    {
        
    }

    public ProductSale(ProductSaleDto dto)
    {
        ProductId = dto.ProductId;
        SalesId = dto.SalesId;
        Quantity = dto.Quantity;
        TotalCost = dto.TotalCost;
        SaleDate = dto.SaleDate;
    }
}