using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Entities;
using BibliotekaAplikacjaProjekt.Extensions;

namespace BibliotekaAplikacjaProjekt.Services
{
    public class OrderService : CrudServiceBase<BookstoreDbContext, Order, OrderDto>
    {
        private BookstoreDbContext _bookstoreDbContext;
        public OrderService(BookstoreDbContext bookstoreDbContext) : base(bookstoreDbContext)
        {
            _bookstoreDbContext = bookstoreDbContext;
        }
        public async Task<OrderDto> GetById(int id)
        {
            var order = await base.GetById(id);
            return order.ToDto();
        }
        public async Task<IEnumerable<OrderDto>> GetByBuyerId(int buyerid)
        {
            var order = await base.Get();
            return order.Where(e => e.BuyerId == buyerid).Select(x => x.ToDto());
        }
        public async Task<IEnumerable<OrderDto>> Get()
        {
            var order = await base.Get();
            return order.Select(e => e.ToDto());
        }
        public async Task<CrudOperationResult<OrderDto>> Create(OrderDto dto)
        {
            var entity = dto.ToEntity();
            var entityId = await base.Create(entity);
            var newDto = await GetById(entity.Id);
            return new CrudOperationResult<OrderDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }
        public async Task<CrudOperationResult<OrderDto>> Delete(int id)
        {
            return await base.Delete(id);
        }
        public async Task<CrudOperationResult<OrderDto>> Update(OrderDto dto)
        {
            var entity = dto.ToEntity();
            return await base.Update(entity);
        }
    }
}
