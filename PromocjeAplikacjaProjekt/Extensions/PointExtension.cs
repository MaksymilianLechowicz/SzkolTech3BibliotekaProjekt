using PromocjeAplikacjaProjekt.Dtos;
using PromocjeAplikacjaProjekt.Entities;

namespace PromocjeAplikacjaProjekt.Extensions
{
    public static class PointExtension
    {
        public static PointDto ToDto(this Point point)
        {
            var result = new PointDto
            {
                Id = point.Id,
                ReaderId = point.ReaderId,
                Amount = point.Amount
            };
            return result;
        }
    }
}
