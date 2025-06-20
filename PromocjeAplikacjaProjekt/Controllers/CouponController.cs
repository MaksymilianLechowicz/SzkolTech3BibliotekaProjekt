using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using PromocjeAplikacjaProjekt.Dtos;
using PromocjeAplikacjaProjekt.Services;

namespace PromocjeAplikacjaProjekt.Controllers
{
    [Microsoft.AspNetCore.Components.Route("/bookstore")]
    public class CouponController : ControllerBase
    {
        private readonly CouponService _couponService;
        public CouponController(CouponService couponService)
        {
            _couponService = couponService;
        }
        [HttpGet("coupons")]
        public async Task<IEnumerable<CouponDto>> Read() => await _couponService.Get();
        [HttpGet("coupons/{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            var couponDto = await _couponService.GetById(id);
            if (couponDto == null)
            {
                return NotFound();
            }
            return Ok(couponDto);
        }
        [HttpGet("CouponByOrder/{id}")]
        public async Task<IActionResult> ReadByDiscount(int id)
        {
            var orderDto = await _couponService.GetDiscount(id);
            if (orderDto == null)
            {
                return NotFound();
            }
            return Ok(orderDto);
        }
        [HttpPost("coupon")]
        public async Task<IActionResult> Create([FromBody] CouponDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _couponService.Create(dto);
            return Ok(operationResult);
        }
        /*[HttpPut("coupon/{id}")]
        public async Task<IActionResult> Update([])*/
        [HttpDelete("coupon/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _couponService.Delete(id);
            return Ok(operationResult);
        }
    }
}
