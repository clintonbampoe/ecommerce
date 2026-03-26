using ECommerceAPI.Data;
using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories;

public class CategoriesRepository
{
    private readonly AppDbContext _dbContext;

    public CategoriesRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        var allCategories = await _dbContext.Categories.ToListAsync();
        return allCategories;
    }

    public async Task<Category> CreateCategory(Category category)
    {
        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> GetCategoryById(int categoryId)
    {
        // TODO: be sure to handle possible null reference in services layer
        var category = await _dbContext.Categories.FindAsync(categoryId);
        return category;
    }

    public async Task<Category?> UpdateCategory(int categoryId, Category updatedCategory)
    {
        var category = await _dbContext.Categories.FindAsync(categoryId);

        // TODO: be sure to handle possible null reference in the services layer
        if (category is null)
        {
            return null;
        }
        
        _dbContext.Entry(category).CurrentValues.SetValues(updatedCategory);
        await _dbContext.SaveChangesAsync();

        return updatedCategory;
    }
    
}