using BibliotekaAplikacjaProjekt.Entities;

namespace BibliotekaAplikacjaProjekt.Dtos
{
    public class OrderDto
    {

        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int Discount { get; set; }
    }
}
