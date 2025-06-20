using BibliotekaAplikacjaProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using PromocjeAplikacjaProjekt.Dtos;
using PromocjeAplikacjaProjekt.Services;

namespace PromocjeAplikacjaProjekt.Controllers
{
    [Microsoft.AspNetCore.Components.Route("/bookstore")]
    public class PointController : ControllerBase
    {
        private readonly PointService _pointService;
        public PointController(PointService pointService)
        {
            _pointService = pointService;
        }
        [HttpGet("points")]
        public async Task<IEnumerable<PointDto>> Read() => await _pointService.Get();
        [HttpGet("points/{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            var pointDto = await _pointService.GetById(id);
            if (pointDto == null)
            {
                return NotFound();
            }
            return Ok(pointDto);
        }
        [HttpPost("point")]
        public async Task<IActionResult> Create([FromBody] PointDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _pointService.Create(dto);
            return Ok(operationResult);
        }
        /*[HttpPut("coupon/{id}")]
        public async Task<IActionResult> Update([])*/
        [HttpDelete("point/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _pointService.Delete(id);
            return Ok(operationResult);
        }
    }

}
