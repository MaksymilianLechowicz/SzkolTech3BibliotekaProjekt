using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Services;
using PromocjeAplikacjaProjekt.Dtos;
using PromocjeAplikacjaProjekt.Entities;
using PromocjeAplikacjaProjekt.Extensions;

namespace PromocjeAplikacjaProjekt.Services
{
    public class PointService : CrudServiceBase<CouponDbContext, Point, PointDto>
    {
        private CouponDbContext _couponstoreDbContext;
        public PointService(CouponDbContext couponstoreDbContext) : base(couponstoreDbContext)
        {
            _couponstoreDbContext = couponstoreDbContext;
        }
        public async Task<PointDto> GetById(int id)
        {
            var coupon = await base.GetById(id);
            return coupon.ToDto();
        }
        public async Task<IEnumerable<PointDto>> Get()
        {
            var coupon = await base.Get();
            return coupon.Select(e => e.ToDto());
        }
        public async Task<CrudOperationResult<PointDto>> Create(PointDto dto)
        {
            var entity = dto.ToEntity();
            var entityId = await base.Create(entity);
            var newDto = await GetById(entity.Id);
            return new CrudOperationResult<PointDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }
        public async Task<CrudOperationResult<PointDto>> Delete(int id)
        {
            return await base.Delete(id);
        }
        public async Task<CrudOperationResult<PointDto>> Update(PointDto dto)
        {
            var entity = dto.ToEntity();
            return await base.Update(entity);
        }
    }
}
