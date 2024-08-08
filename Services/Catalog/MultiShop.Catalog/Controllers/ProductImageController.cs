using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _categoryService;

        public ProductImageController(IProductImageService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> ProductImageListAsync()
        {
            var values = await _categoryService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProductImageByIdAsync(string id)
        {
            var value = await _categoryService.GetByIdProductImageAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _categoryService.CreateProductImageAsync(createProductImageDto);
            return Ok("Product Image is created !");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _categoryService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Product Image is updated !");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImageAsync(string id)
        {
            await _categoryService.DeleteProductImageAsync(id);
            return Ok("Product Image is deleted !");
        }
    }
}
