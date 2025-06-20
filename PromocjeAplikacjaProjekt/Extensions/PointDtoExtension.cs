using PromocjeAplikacjaProjekt.Dtos;
using PromocjeAplikacjaProjekt.Entities;

namespace PromocjeAplikacjaProjekt.Extensions
{
    public static class PointDtoExtension
    {
        public static Point ToEntity(this PointDto dto)
        {
            return new Point
            {
                Id = dto.Id,
                ReaderId = dto.ReaderId,
                Amount = dto.Amount,
            };
        }
    }
}
