namespace ECommerceAPI.Models.Dto;

public class CategoryDto : ICategory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    /*
     * NOTE
     * This DTO is meant to efficiently return a Category object with the navigation properties
     * It discards any other optional data to make transferring the object easier and more efficient.
     */
    public CategoryDto()
    {
        
    }
    public CategoryDto(Category category)
    {
        Id = category.Id;
        Name = category.Name;
    }
}