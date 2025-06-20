using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Entities;
using CzytelnikAplikacjaProjekt.Dtos;
using CzytelnikAplikacjaProjekt.Entities;

namespace CzytelnikAplikacjaProjekt.Extensions
{
    public static class ReaderExtension
    {
        public static ReaderDto ToDto(this Reader reader)
        {
            var result = new ReaderDto
            {
                Id = reader.Id,
                Name = reader.Name,
                Surname = reader.Surname,
                Email = reader.Email
            };
            return result;
        }
    }
}
