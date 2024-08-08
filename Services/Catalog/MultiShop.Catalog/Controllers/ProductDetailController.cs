using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _categoryService;

        public ProductDetailController(IProductDetailService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> ProductDetailListAsync()
        {
            var values = await _categoryService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProductDetailByIdAsync(string id)
        {
            var value = await _categoryService.GetByIdProductDetailAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _categoryService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Product Detail is created !");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _categoryService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Product Detail is updated !");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetailAsync(string id)
        {
            await _categoryService.DeleteProductDetailAsync(id);
            return Ok("Product Detail is deleted !");
        }
    }
}
