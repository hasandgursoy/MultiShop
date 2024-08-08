using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
           _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> CategoryListAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CategoryByIdAsync(string id)
        {
            var value = await _categoryService.GetByIdCategoryAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Category is created !");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Category is updated !");    

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryAsync(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Category is deleted !");
        }
    }
}
