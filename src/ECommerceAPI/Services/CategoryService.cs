using ECommerceAPI.Models;
using ECommerceAPI.Models.Dto;
using ECommerceAPI.Models.Pagination;
using ECommerceAPI.Repositories;

namespace ECommerceAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly CategoriesRepository _repository;

    public CategoryService(CategoriesRepository repository)
    {
        _repository = repository;
    }
    
    /*
     * NOTE
     * In this class, methods that return nullable objects are like that by design.
     * If the return object a method gets from the repository class is nullable or empty, the method in this case
     * returns an empty object or list(depending on the type) to the calling method.
     * The controller is supposed to handle this gracefully.
     * That is: it should print a meaningful message if it receives an empty list and the normal response if otherwise
     */
    
    public async Task<PagedResponse<CategoryDto>> GetAllCategories(PaginationParams paginationParams)
    {
        var categories = await _repository.GetAllCategories(paginationParams);

        var dtos = categories.Data.Select(category => new CategoryDto(category));

        
        return new PagedResponse<CategoryDto>(dtos, categories.PageNumber, categories.PageSize, categories.TotalRecords);
    }

    public async Task<CategoryDto?> GetCategoryById(int categoryId)
    {
        var category = await _repository.GetCategoryById(categoryId);

        if (category is null)
        {
            return null;
        }

        return new CategoryDto(category);
    }


    public async Task<CategoryDto> CreateCategory(CategoryDto dto)
    {
        await _repository.CreateCategory(new Category(dto));
        return dto;
    }

    public async Task<CategoryDto?> UpdateCategory(int categoryId, CategoryDto dto)
    {
        var category = await _repository.UpdateCategory(categoryId, new Category(dto));

        if (category is null)
        {
            return null;
        }

        return new CategoryDto(category);
    }
}