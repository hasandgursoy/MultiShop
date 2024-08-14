using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponListAsync()
        {
            var result = await _discountService.GetAllDiscountCouponAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponByIdAsync(int id)
        {
            var result = await _discountService.GetByIdDiscountCouponAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            await _discountService.CreateDiscountCouponAsync(createCouponDto);
            return Ok("Coupon created successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCouponAsync(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("Coupon deleted successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            await _discountService.UpdateDiscountCouponAsync(updateCouponDto);
            return Ok("Coupon updated successfully");
        }

    }
}
