
using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Entities;
using BibliotekaAplikacjaProjekt.Services;
using BibliotekaAplikacjaProjekt;
using CzytelnikAplikacjaProjekt;
using CzytelnikAplikacjaProjekt.Entities;
using CzytelnikAplikacjaProjekt.Dtos;
using CzytelnikAplikacjaProjekt.Extensions;

namespace CzytelnikAplikacjaProjekt.Services
{
    public class ReaderService : CrudServiceBase<ReaderDbContext, Reader, ReaderDto>
    {
        private ReaderDbContext _readerDbContext;
        public ReaderService(ReaderDbContext readerDbContext) : base(readerDbContext)
        {
            _readerDbContext = readerDbContext;
        }
        public async Task<ReaderDto> GetById(int id)
        {
            var reader = await base.GetById(id);
            return reader.ToDto();
        }
        public async Task<IEnumerable<ReaderDto>> Get()
        {
            var reader = await base.Get();
            return reader.Select(e => e.ToDto());
        }
        public async Task<CrudOperationResult<ReaderDto>> Create(ReaderDto dto)
        {
            var entity = dto.ToEntity();
            var entityId = await base.Create(entity);
            var newDto = await GetById(entity.Id);
            return new CrudOperationResult<ReaderDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }
        public async Task<CrudOperationResult<ReaderDto>> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}
