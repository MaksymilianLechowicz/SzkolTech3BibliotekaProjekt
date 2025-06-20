using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using BibliotekaAplikacjaProjekt.Dtos;
using BibliotekaAplikacjaProjekt.Entities;

namespace BibliotekaAplikacjaProjekt.Services
{
    public class CrudServiceBase<TDbContext, TEntity, TDto>
        where TDbContext : DbContext
        where TEntity : BaseEntity
        where TDto : class
    {
        private readonly TDbContext _dbContext;
        protected virtual Task OnBeforeRecordCreatedAsync(TDbContext dbCOntext, TEntity entity) => Task.CompletedTask;
        protected virtual Task OnAfterRecordCreatedAsync(TDbContext dbCOntext, TEntity entity) => Task.CompletedTask;
        public CrudServiceBase(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CrudOperationResult<TDto>> Delete(int id)
        {
            var entity = await _dbContext
                .Set<TEntity>()
                .SingleOrDefaultAsync(e => e.Id!.Equals(id));
            if (entity == null)
            {
                return new CrudOperationResult<TDto>
                {
                    Status = CrudOperationResultStatus.RecordNotFound
                };
            }

            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return new CrudOperationResult<TDto>
            {
                Status = CrudOperationResultStatus.Success,
            };


        }
        public async Task<int> Create(TEntity entity)
        {
            await OnBeforeRecordCreatedAsync(_dbContext, entity);
            _dbContext
                .Set<TEntity>()
                .Add(entity);
            await _dbContext.SaveChangesAsync();

            await OnAfterRecordCreatedAsync(_dbContext, entity);
            return entity.Id;

        }
        public async Task<CrudOperationResult<TDto>> Update(TEntity newEntity)
        {
            var entityBeforeUpdate = await GetById(newEntity.Id);
            if (entityBeforeUpdate == null)
            {
                return new CrudOperationResult<TDto>
                {
                    Status = CrudOperationResultStatus.RecordNotFound
                };
            }
            _dbContext.Entry(newEntity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return new CrudOperationResult<TDto>
            {
                Status = CrudOperationResultStatus.Success,
            };
        }
        protected async virtual Task<TEntity> GetById(int id)
        {
            var baseEntity = _dbContext
                .Set<TEntity>()
                .AsNoTracking()
                .Where(e => e.Id!.Equals(id));
            var entity = await ConfigureFormIncludes(baseEntity)
                .SingleOrDefaultAsync();
            return entity;
        }

        public async virtual Task<IEnumerable<TEntity>> Get()
        {
            var baseEntities = _dbContext
                .Set<TEntity>()
                .AsNoTracking();

            var entities = await ConfigureFormIncludes(baseEntities)
                .ToListAsync();

            return entities;
        }
        protected virtual IQueryable<TEntity> ConfigureFormIncludes(IQueryable<TEntity> linq)
        {
            return linq;
        }
    }
}

