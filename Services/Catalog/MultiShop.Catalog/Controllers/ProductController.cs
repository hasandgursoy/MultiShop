using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _categoryService;

        public ProductController(IProductService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> ProductListAsync()
        {
            var values = await _categoryService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProductByIdAsync(string id)
        {
            var value = await _categoryService.GetByIdProductAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(CreateProductDto createProductDto)
        {
            await _categoryService.CreateProductAsync(createProductDto);
            return Ok("Product is created !");
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _categoryService.UpdateProductAsync(updateProductDto);
            return Ok("Product is updated !");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync(string id)
        {
            await _categoryService.DeleteProductAsync(id);
            return Ok("Product is deleted !");
        }
    }
}
