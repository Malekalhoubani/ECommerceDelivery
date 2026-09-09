using ECommerceService.Application.DTOs;
using ECommerceService.Application.DTOs.Products;
using ECommerceService.Application.Models;
using ECommerceService.Application.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceService.Api.Controllers.ProductsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProductDto dto,CancellationToken cancellationToken)
        {
            var productId = await _productService.CreateAsync(dto,cancellationToken);

            return CreatedAtAction(nameof(GetById),new { id = productId },productId);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,UpdateProductDto dto,CancellationToken cancellationToken)
        {
            await _productService.UpdateAsync(id,dto,cancellationToken);

            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
        {
            await _productService.DeleteAsync(id,cancellationToken);
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById(int id,CancellationToken cancellationToken)
        {
            var product = await _productService.GetByIdAsync(id,cancellationToken);
            return Ok(product);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAll(CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllAsync(cancellationToken);
            return Ok(products);
        }
        [HttpGet("search")]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> Search([FromQuery] ProductFilterModel filter,CancellationToken cancellationToken)
        {
            var products = await _productService.SearchAsync(filter,cancellationToken);

            return Ok(products);
        }
    }
}
