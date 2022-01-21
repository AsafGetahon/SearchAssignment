using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AutoMapper;
using Searchassignment.Dal.Repositories;

namespace Searchassignment.Service.Services
{
    public interface IGenericDataService<DTOEntity, TEntity>
    {

        Task<IEnumerable<DTOEntity>> GetAllAsync();

        Task<DTOEntity> GetByIdAsync(object id);

        Task<DTOEntity> GetAsync(Expression<Func<TEntity, bool>> where, string[] include = null);

        Task<DTOEntity> GetNoTrackingAsync(Expression<Func<TEntity, bool>> where, string[] include = null);

        Task<IEnumerable<DTOEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, string[] include = null);

        Task<IEnumerable<DTOEntity>> GetManyNoTrackingAsync(Expression<Func<TEntity, bool>> where, string[] include = null);

        Task<DTOEntity> AddAsync(DTOEntity item);

        Task<DTOEntity> AddDetachedAsync(DTOEntity item);

        Task UpdateAsync(DTOEntity item);

        Task UpdateDetachedAsync(DTOEntity item);

        Task UpdateAsync(DTOEntity item, string[] excluded);

        Task DeleteAsync(object id);

        Task AddRangeAsync(List<DTOEntity> items);

        Task UpdateRangeAsync(List<DTOEntity> items);

        Task RemoveRangeAsync(Expression<Func<TEntity, bool>> where);

    }



    public abstract class GenericDataService<DTOEntity, TEntity> : IGenericDataService<DTOEntity, TEntity> where DTOEntity : class where TEntity : class
    {

        protected readonly IMapper _mapper;

        protected readonly IGenericRepository<TEntity> _repository;



        public GenericDataService(IMapper mapper, IGenericRepository<TEntity> repository)

        {

            _mapper = mapper;

            _repository = repository;

        }


        public virtual async Task<IEnumerable<DTOEntity>> GetAllAsync()

        {
            var entities = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<DTOEntity>>(entities);

        }

        public virtual async Task<IEnumerable<DTOEntity>> GetAllQuery()

        {
            var entities = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<DTOEntity>>(entities);

        }

        public virtual async Task<DTOEntity> GetByIdAsync(object id)

        {

            var entity = await _repository.GetByIdAsync(id);

            return _mapper.Map<DTOEntity>(entity);

        }

        public async Task<DTOEntity> GetAsync(Expression<Func<TEntity, bool>> where, string[] include = null)

        {

            var entity = await _repository.GetAsync(where, include);

            return _mapper.Map<DTOEntity>(entity);

        }

        public async Task<DTOEntity> GetNoTrackingAsync(Expression<Func<TEntity, bool>> where, string[] include)

        {

            var entity = await _repository.GetNoTrackingAsync(where, include);

            return _mapper.Map<DTOEntity>(entity);

        }

        public async Task<IEnumerable<DTOEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, string[] include)

        {

            var entities = await _repository.GetManyAsync(where, include);

            return _mapper.Map<IEnumerable<DTOEntity>>(entities);

        }



        public async Task<IEnumerable<DTOEntity>> GetManyNoTrackingAsync(Expression<Func<TEntity, bool>> where, string[] include)

        {

            var entities = await _repository.GetManyNoTrackingAsync(where, include);

            return _mapper.Map<IEnumerable<DTOEntity>>(entities);

        }



        public virtual async Task<DTOEntity> AddAsync(DTOEntity item)

        {

            var entity = _mapper.Map<TEntity>(item);

            entity = await _repository.AddAsync(entity);

            return _mapper.Map<DTOEntity>(entity);

        }



        public virtual async Task<DTOEntity> AddDetachedAsync(DTOEntity item)

        {

            var entity = _mapper.Map<TEntity>(item);



            entity = await _repository.AddDetachedAsync(entity);

            return _mapper.Map<DTOEntity>(entity);

        }



        public virtual async Task UpdateAsync(DTOEntity item)

        {

            var entity = _mapper.Map<TEntity>(item);

            await _repository.UpdateAsync(entity);

        }



        public virtual async Task UpdateDetachedAsync(DTOEntity item)

        {

            var entity = _mapper.Map<TEntity>(item);

            await _repository.UpdateDetachedAsync(entity);

        }



        public async Task UpdateAsync(DTOEntity item, string[] excluded)

        {

            var entity = _mapper.Map<TEntity>(item);

            await _repository.UpdateAsync(entity, excluded);

        }



        public virtual async Task DeleteAsync(object id)

        {

            await _repository.DeleteAsync(id);

        }



        public async Task AddRangeAsync(List<DTOEntity> items)

        {

            var entities = _mapper.Map<List<TEntity>>(items);

            await _repository.AddRangeAsync(entities);

        }


        public async Task UpdateRangeAsync(List<DTOEntity> items)

        {
            var entities = _mapper.Map<List<TEntity>>(items);

            await _repository.UpdateRangeAsync(entities);
        }



        public async Task RemoveRangeAsync(Expression<Func<TEntity, bool>> where)

        {

            await _repository.RemoveRangeAsync(where);

        }
    }
}
