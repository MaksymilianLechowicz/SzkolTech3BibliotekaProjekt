using Microsoft.EntityFrameworkCore;
using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Extensions;
using BibliotekaAplikacjaProjekt.Entities;
using BibliotekaAplikacjaProjekt;

namespace BibliotekaAplikacjaProjekt.Services
{
    public class BookService : CrudServiceBase<BookstoreDbContext, Book, BookDto>
    {
        private BookstoreDbContext _bookstoreDbContext;
        public BookService(BookstoreDbContext bookstoreDbContext) : base(bookstoreDbContext)
        {
            _bookstoreDbContext = bookstoreDbContext;
        }
        public async Task<BookDto> GetById(int id)
        {
            var book = await base.GetById(id);
            return book.ToDto();
        }
        public async Task<IEnumerable<BookDto>> Get()
        {
            var book = await base.Get();
            return book.Select(e => e.ToDto());
        }
        public async Task<CrudOperationResult<BookDto>> Create(BookDto dto)
        {
            var entity = dto.ToEntity();
            var entityId = await base.Create(entity);
            var newDto = await GetById(entity.Id);
            return new CrudOperationResult<BookDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }
        public async Task<CrudOperationResult<BookDto>> Delete(int id)
        {
            return await base.Delete(id);
        }
        public async Task<BookDto> Update(int id, BookDto dto)
        {
            var book = await _bookstoreDbContext.Books.FindAsync(id);
            if (book == null) return null;

            book.Author = dto.Author;
            book.BookTitle = dto.BookTitle;
            book.IsActive = dto.isActive;
            
            await _bookstoreDbContext.SaveChangesAsync();

            return new BookDto
            {
                Id = book.Id,
                Author = book.Author,
                BookTitle = book.BookTitle,
                isActive = book.IsActive
            };
        }
    }
}
