using CzytelnikAplikacjaProjekt.Resolver;
using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Services;
using CzytelnikAplikacjaProjekt.Dtos;
using CzytelnikAplikacjaProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using PromocjeAplikacjaProjekt.Dtos;

namespace CzytelnikAplikacjaProjekt.Controllers
{
    [Microsoft.AspNetCore.Components.Route("/bookstore")]
    public class ReaderController : ControllerBase
    {
        private readonly ReaderService _readerService;
        private readonly OrderResolver _orderResolver;
        private readonly CouponResolver _couponResolver;
        public ReaderController(ReaderService readerService, OrderResolver orderResolver, CouponResolver couponResolver)
        {
            _readerService = readerService;
            _orderResolver = orderResolver;
            _couponResolver = couponResolver;
        }
        [HttpGet("readers")]
        public async Task<IEnumerable<ReaderDto>> Read() => await _readerService.Get();
        [HttpGet("readers/{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            var readerDto = await _readerService.GetById(id);
            if (readerDto == null)
            {
                return NotFound();
            }
            var orders = await _orderResolver.GetOrdersByReaderId(id);
            Task<List<CouponDto>> coupons = _couponResolver.GetCouponsByDiscount(1);
            foreach (OrderDto i in orders) {
                coupons = _couponResolver.GetCouponsByDiscount(i.Discount);
                break;
                    }
            return Ok(new
            {
                Id = readerDto.Id,
                Name = readerDto.Name,
                Surname = readerDto.Surname,
                Email = readerDto.Email,
                Orders = orders,
                Coupons = coupons
            }) ;
        
        }
        [HttpPost("reader")]
        public async Task<IActionResult> Create([FromBody] ReaderDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _readerService.Create(dto);
            return Ok(operationResult);
        }
        [HttpDelete("reader/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _readerService.Delete(id);
            return Ok(operationResult);
        }
       
    }
}
