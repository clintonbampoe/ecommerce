using ECommerceAPI.Data;
using ECommerceAPI.Models;
using ECommerceAPI.Models.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories;

public class CategoriesRepository
{
    private readonly AppDbContext _dbContext;

    public CategoriesRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<PagedResponse<Category>> GetAllCategories(PaginationParams parameters)
    {
        var totalRecords = await _dbContext.Categories.CountAsync();
        var categories = await _dbContext.Categories.Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync();

        var pagedResponse =
            new PagedResponse<Category>(categories, parameters.PageNumber, parameters.PageSize, totalRecords);

        return pagedResponse;
    }

    public async Task<Category> CreateCategory(Category category)
    {
        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> GetCategoryById(int categoryId)
    {
        var category = await _dbContext.Categories.FindAsync(categoryId);
        return category;
    }

    public async Task<Category?> UpdateCategory(int categoryId, Category updatedCategory)
    {
        var category = await _dbContext.Categories.FindAsync(categoryId);

        if (category is null)
        {
            return null;
        }
        
        _dbContext.Entry(category).CurrentValues.SetValues(updatedCategory);
        await _dbContext.SaveChangesAsync();

        return updatedCategory;
    }
    
}