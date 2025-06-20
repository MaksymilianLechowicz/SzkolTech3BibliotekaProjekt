using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Entities;

namespace BibliotekaAplikacjaProjekt.Extensions
{
    public static class OrderDtoExtension
    {
        public static Order ToEntity(this OrderDto dto)
        {
            return new Order
            {
                Id = dto.Id,
                BuyerId = dto.BuyerId,
                Discount = dto.Discount,
            };
        }
    }
}
