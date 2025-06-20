using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Entities;
using System.Runtime.CompilerServices;

namespace BibliotekaAplikacjaProjekt.Extensions
{
    public static class BookExtension
    {
        public static BookDto ToDto(this Book book) 
        {
            var result = new BookDto
            {
                Id = book.Id,
                BookTitle = book.BookTitle,
                Author = book.Author,
                isActive = book.IsActive
            };
            return result;
        }
    }
}
