using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Entities;

namespace BibliotekaAplikacjaProjekt.Extensions
{
    public static class BookDtoExtension
    {
        public static Book ToEntity(this BookDto dto)
        {
            return new Book
            {
                Id = dto.Id,
                BookTitle = dto.BookTitle,
                Author = dto.Author,
                IsActive = dto.isActive
            };
        }
    }
}
