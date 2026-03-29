using ECommerceAPI.Models;
using ECommerceAPI.Models.Dto;
using ECommerceAPI.Models.Pagination;

namespace ECommerceAPI.Services;

public interface ICategoryService
{
    Task<PagedResponse<CategoryDto>> GetAllCategories(PaginationParams paginationParams);
    Task<CategoryDto?> GetCategoryById(int categoryId);
    Task<CategoryDto> CreateCategory(CategoryDto dto);
    Task<CategoryDto?> UpdateCategory(int categoryId, CategoryDto dto);
}