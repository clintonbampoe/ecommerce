using ECommerceAPI.Models;

namespace ECommerceAPI.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category?> GetCategoryById(int categoryId);
    Task<Category> CreateCategory(Category category);
    Task<Category?> UpdateCategory(int categoryId, Category updatedCategory);
}