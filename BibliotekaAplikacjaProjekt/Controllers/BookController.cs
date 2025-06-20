using Microsoft.AspNetCore.Mvc;
using BibliotekaAplikacjaProjekt.Services;
using BibliotekaAplikacjaProjekt.Dtos;
namespace BibliotekaAplikacjaProjekt.Controllers
{
   [Microsoft.AspNetCore.Components.Route("/bookstore")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("books")]
        public async Task<IEnumerable<BookDto>> Read() => await _bookService.Get();
        [HttpGet("books/{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            var bookDto = await _bookService.GetById(id);
            if (bookDto == null)
            {
                return NotFound();
            }
            return Ok(bookDto);
        }
        [HttpPost("book")]
        public async Task<IActionResult> Create([FromBody] BookDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _bookService.Create(dto);
            return Ok(operationResult);
        }
        [HttpDelete("book/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _bookService.Delete(id);
            return Ok(operationResult);
        }
        [HttpPut("bookupdate/{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] BookDto dto)
        {
            var updated = await _bookService.Update(id,dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
        
    }
}
