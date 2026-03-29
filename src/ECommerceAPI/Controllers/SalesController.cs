using ECommerceAPI.Models.Dto;
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
        public async Task<ActionResult<IEnumerable<ProductSaleDto>>> GetSales()
        {
            return Ok(await _saleService.GetAll());
        }

        // GET: api/Sales/5
        [HttpGet("bySalesId/{id}")]
        public async Task<ActionResult<IEnumerable<ProductSaleDto>>> GetBySalesId(int id)
        {
            return Ok(await _saleService.GetBySaleId(id));
        }

        // GET: api/products/5
        [HttpGet("byProductId/{id}")]
        public async Task<ActionResult<IEnumerable<ProductSaleDto>>> GetByProductId(int productId)
        {
            return Ok(await _saleService.GetByProductId(productId));
        }

        // POST: api/Sales
        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProductSaleDto>>> PostSale([FromBody] SalesCreateDto sale)
        {
            return Ok(await _saleService.PostNewEntry(sale));
        }
        
    }
}
