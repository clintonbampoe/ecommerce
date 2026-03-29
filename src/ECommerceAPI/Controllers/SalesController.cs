using ECommerceAPI.Models.Dto;
using ECommerceAPI.Models.Pagination;
using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Services;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<PagedResponse<ProductSaleDto>>> GetSales([FromQuery] PaginationParams paginationParams)
        {
            return Ok(await _saleService.GetAll(paginationParams));
        }

        // GET: api/Sales/5
        [HttpGet("bySalesId/{id}")]
        public async Task<ActionResult<PagedResponse<ProductSaleDto>>> GetBySalesId(int id, [FromQuery] PaginationParams paginationParams)
        {
            return Ok(await _saleService.GetBySaleId(id, paginationParams));
        }

        // GET: api/products/5
        [HttpGet("byProductId/{id}")]
        public async Task<ActionResult<PagedResponse<ProductSaleDto>>> GetByProductId(int id, [FromQuery] PaginationParams paginationParams)
        {
            return Ok(await _saleService.GetByProductId(id, paginationParams));
        }

        // POST: api/Sales
        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProductSaleDto>>> PostSale([FromBody] SalesCreateDto sale)
        {
            return Ok(await _saleService.PostNewEntry(sale));
        }
        
    }
}
