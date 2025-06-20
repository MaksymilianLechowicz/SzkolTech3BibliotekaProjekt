using PromocjeAplikacjaProjekt.Dtos;
using PromocjeAplikacjaProjekt.Entities;

namespace PromocjeAplikacjaProjekt.Extensions
{
    public static class CouponExtension
    {
        public static CouponDto ToDto(this Coupon coupon)
        {
            var result = new CouponDto
            {
                Id = coupon.Id,
                MultiplierDiscount = coupon.MultiplierDiscount,
                ExpirationDate = coupon.ExpirationDate
            };
            return result;
        }
    }
}


