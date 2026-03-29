using ECommerceAPI.Models;
using ECommerceAPI.Models.Dto;
using ECommerceAPI.Models.Pagination;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceAPI.Services;

public interface IProductService
{
    Task<PagedResponse<ProductDto>> GetAllProducts(PaginationParams paginationParams);
    Task<ProductDto?> GetProductById(int productId);
    Task<ProductDto> CreateProduct(ProductDto product);
}