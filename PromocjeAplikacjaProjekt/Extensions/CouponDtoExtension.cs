using PromocjeAplikacjaProjekt.Dtos;
using PromocjeAplikacjaProjekt.Entities;

namespace PromocjeAplikacjaProjekt.Extensions
{
    public static class CouponDtoExtension
    {
        public static Coupon ToEntity(this CouponDto dto)
        {
            return new Coupon
            {
                Id = dto.Id,
                MultiplierDiscount  = dto.MultiplierDiscount,
                ExpirationDate  = dto.ExpirationDate
            };
        }
    }
}
