namespace ECommerceAPI.Models.Dto;

public class ProductSaleDto
{
    public int ProductId { get; set; }
    public int SalesId { get; set; }
    
    public int Quantity { get; set; }
    public double TotalCost { get; set; }

    public DateTime SaleDate { get; set; }

    public ProductSaleDto()
    {
        
    }

    public ProductSaleDto(ProductSale productSale)
    {
        ProductId = productSale.ProductId;
        SalesId = productSale.SalesId;
        Quantity = productSale.Quantity;
        TotalCost = productSale.TotalCost;
        SaleDate = productSale.SaleDate;
    }
}