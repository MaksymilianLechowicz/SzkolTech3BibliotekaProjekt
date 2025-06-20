using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekaAplikacjaProjekt.Controllers
{
    [Microsoft.AspNetCore.Components.Route("/bookstore")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("Orders")]
        public async Task<IEnumerable<OrderDto>> Read() => await _orderService.Get();
        [HttpGet("Orders/{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            var orderDto = await _orderService.GetById(id);
            if (orderDto == null)
            {
                return NotFound();
            }
            return Ok(orderDto);
        }
        [HttpGet("OrdersBuy/{id}")]
        public async Task<IActionResult> ReadByBuyerId(int id)
        {
            var orderDto = await _orderService.GetByBuyerId(id);
            if (orderDto == null)
            {
                return NotFound();
            }
            return Ok(orderDto);
        }
        [HttpPost("Order")]
        public async Task<IActionResult> Create([FromBody] OrderDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _orderService.Create(dto);
            return Ok(operationResult);
        }
        [HttpDelete("order/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _orderService.Delete(id);
            return Ok(operationResult);
        }
    }
}
