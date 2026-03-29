using ECommerceAPI.Models.Dto;
using ECommerceAPI.Models.Pagination;
using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Services;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<PagedResponse<CategoryDto>>> GetCategories([FromQuery] PaginationParams paginationParams)
        {
            return Ok(await _service.GetAllCategories(paginationParams));
        }

        // GET: api/Categories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            return Ok(await _service.GetCategoryById(id));
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDto dto)
        {
            return Ok(await _service.UpdateCategory(id, dto));
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory(CategoryDto dto)
        {
            return Ok(await _service.CreateCategory(dto));
        }

        
    }
}
