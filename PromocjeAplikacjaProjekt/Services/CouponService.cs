using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Entities;
using BibliotekaAplikacjaProjekt.Services;
using BibliotekaAplikacjaProjekt;
using PromocjeAplikacjaProjekt.Entities;
using PromocjeAplikacjaProjekt.Dtos;
using PromocjeAplikacjaProjekt.Extensions;

namespace PromocjeAplikacjaProjekt.Services
{
    public class CouponService : CrudServiceBase<CouponDbContext, Coupon, CouponDto>
    {
        private CouponDbContext _couponstoreDbContext;
        public CouponService(CouponDbContext couponstoreDbContext) : base(couponstoreDbContext)
        {
            _couponstoreDbContext = couponstoreDbContext;
        }
        public async Task<CouponDto> GetById(int id)
        {
            var coupon = await base.GetById(id);
            return coupon.ToDto();
        }
        public async Task<IEnumerable<CouponDto>> Get()
        {
            var coupon = await base.Get();
            return coupon.Select(e => e.ToDto());
        }
        public async Task<IEnumerable<CouponDto>> GetDiscount(int buyerid)
        {
            var order = await base.Get();
            return order.Where(e => e.Id == buyerid).Select(x => x.ToDto());
        }
        public async Task<CrudOperationResult<CouponDto>> Create(CouponDto dto)
        {
            var entity = dto.ToEntity();
            var entityId = await base.Create(entity);
            var newDto = await GetById(entity.Id);
            return new CrudOperationResult<CouponDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }
        public async Task<CrudOperationResult<CouponDto>> Delete(int id)
        {
            return await base.Delete(id);
        }
        public async Task<CrudOperationResult<CouponDto>> Update(CouponDto dto)
        {
            var entity = dto.ToEntity();
            return await base.Update(entity);
        }
    }
}
