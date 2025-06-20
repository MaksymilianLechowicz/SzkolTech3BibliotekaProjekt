using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Entities;
using CzytelnikAplikacjaProjekt.Dtos;
using CzytelnikAplikacjaProjekt.Entities;

namespace CzytelnikAplikacjaProjekt.Extensions
{
    public static class ReaderDtoExtension
    {
        public static Reader ToEntity(this ReaderDto dto)
        {
            return new Reader
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email
            };
        }
    }
}
