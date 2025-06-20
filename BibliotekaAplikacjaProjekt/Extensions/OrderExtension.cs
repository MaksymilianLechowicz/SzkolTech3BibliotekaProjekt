using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Entities;

namespace BibliotekaAplikacjaProjekt.Extensions
{
    public static class OrderExtension
    {
        public static OrderDto ToDto(this Order order)
        {
            var result = new OrderDto
            {
                Id = order.Id,
                BuyerId = order.BuyerId,
                Discount = order.Discount
            };
            return result;
        }
    }
}
