using ECommerceAPI.Models;
using ECommerceAPI.Models.Dto;

namespace ECommerceAPI.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategories();
    Task<CategoryDto?> GetCategoryById(int categoryId);
    Task<CategoryDto> CreateCategory(CategoryDto dto);
    Task<CategoryDto?> UpdateCategory(int categoryId, CategoryDto dto);
}