using Microsoft.EntityFrameworkCore;
using Searchassignment.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Searchassignment.Common.Extentions;


namespace Searchassignment.Dal.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(object id);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where, string[] include = null);

        Task<TEntity> GetNoTrackingAsync(Expression<Func<TEntity, bool>> where, string[] include = null);

        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, string[] include = null);

        Task<IEnumerable<TEntity>> GetManyNoTrackingAsync(Expression<Func<TEntity, bool>> where, string[] include = null);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> AddDetachedAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task UpdateDetachedAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity, string[] excluded);

        Task DeleteAsync(object id);

        Task AddRangeAsync(List<TEntity> entities);

        Task UpdateRangeAsync(List<TEntity> entities);

        Task RemoveRangeAsync(Expression<Func<TEntity, bool>> where);





        IQueryable<TEntity> GetAll();

        TEntity GetById(object id);

        TEntity Get(Expression<Func<TEntity, bool>> where);

        TEntity GetNoTracking(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> GetManyNoTracking(Expression<Func<TEntity, bool>> where);

        TEntity Add(TEntity entity);

        TEntity AddDetached(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Update(TEntity entity, string[] excluded);

        void Delete(object id);

        void RemoveRange(Expression<Func<TEntity, bool>> where);

    }


    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly DbEntity _dbContext;

        public GenericRepository(DbEntity dbContext)
        {

            _dbContext = dbContext;

        }



        #region Async



        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }



        public async Task<TEntity> GetByIdAsync(object id)

        {

            return await _dbContext.Set<TEntity>().FindAsync(id);

        }



        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where, string[] include = null)

        {

            return await _dbContext.Set<TEntity>().Where(where).IncludeMultiple(include).FirstOrDefaultAsync();

        }


        public async Task<TEntity> GetNoTrackingAsync(Expression<Func<TEntity, bool>> where, string[] include = null)

        {

            return await _dbContext.Set<TEntity>().Where(where).AsNoTracking().IncludeMultiple(include).FirstOrDefaultAsync();

        }



        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, string[] include = null)

        {

            return await _dbContext.Set<TEntity>().Where(where).IncludeMultiple(include).ToListAsync();

        }


        public async Task<IEnumerable<TEntity>> GetManyNoTrackingAsync(Expression<Func<TEntity, bool>> where, string[] include = null)

        {

            return await _dbContext.Set<TEntity>().Where(where).IncludeMultiple(include).AsNoTracking().ToListAsync();

        }


        public async Task<TEntity> AddAsync(TEntity entity)

        {
            //var isExist = _dbContext
            await _dbContext.Set<TEntity>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;

        }


        public async Task<TEntity> AddDetachedAsync(TEntity entity)

        {

            await _dbContext.Set<TEntity>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();



            _dbContext.Entry(entity).State = EntityState.Detached;


            return entity;

        }


        public async Task UpdateAsync(TEntity entity)

        {

            _dbContext.Set<TEntity>().Update(entity);

            await _dbContext.SaveChangesAsync();

        }


        public async Task UpdateDetachedAsync(TEntity entity)

        {

            _dbContext.Set<TEntity>().Update(entity);

            await _dbContext.SaveChangesAsync();



            _dbContext.Entry(entity).State = EntityState.Detached;

        }


        public async Task<TEntity> UpdateAsync(TEntity entity, string[] excluded)

        {

            _dbContext.Set<TEntity>().Update(entity);



            foreach (var property in excluded)

            {

                _dbContext.Entry(entity).Property(property).IsModified = false;

            }



            await _dbContext.SaveChangesAsync();



            return entity;

        }



        public async Task DeleteAsync(object id)

        {

            var entity = await GetByIdAsync(id);

            _dbContext.Set<TEntity>().Remove(entity);

            await _dbContext.SaveChangesAsync();

        }



        public async Task AddRangeAsync(List<TEntity> entities)

        {

            await _dbContext.AddRangeAsync(entities);

            await _dbContext.SaveChangesAsync();

        }



        public async Task UpdateRangeAsync(List<TEntity> entities)

        {

            _dbContext.UpdateRange(entities);

            await _dbContext.SaveChangesAsync();

        }



        public async Task RemoveRangeAsync(Expression<Func<TEntity, bool>> where)

        {

            var entities = await GetManyNoTrackingAsync(where);

            _dbContext.RemoveRange(entities);

            await _dbContext.SaveChangesAsync();

        }



        #endregion



        #region Sync

        public IQueryable<TEntity> GetAll()

        {

            return _dbContext.Set<TEntity>();

        }



        public TEntity GetById(object id)

        {

            return _dbContext.Set<TEntity>().Find(id);

        }



        public TEntity Get(Expression<Func<TEntity, bool>> where)

        {

            return _dbContext.Set<TEntity>().Where(where).FirstOrDefault();

        }



        public TEntity GetNoTracking(Expression<Func<TEntity, bool>> where)

        {

            return _dbContext.Set<TEntity>().Where(where).AsNoTracking().FirstOrDefault();

        }



        public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)

        {

            return _dbContext.Set<TEntity>().Where(where);

        }



        public IQueryable<TEntity> GetManyNoTracking(Expression<Func<TEntity, bool>> where)

        {

            return _dbContext.Set<TEntity>().Where(where).AsNoTracking();

        }



        public TEntity Add(TEntity entity)

        {

            _dbContext.Set<TEntity>().Add(entity);

            _dbContext.SaveChanges();



            return entity;

        }



        public TEntity AddDetached(TEntity entity)

        {

            _dbContext.Set<TEntity>().Add(entity);

            _dbContext.SaveChanges();



            _dbContext.Entry(entity).State = EntityState.Detached;



            return entity;

        }



        public TEntity Update(TEntity entity)

        {

            _dbContext.Set<TEntity>().Update(entity);

            _dbContext.SaveChanges();



            return entity;

        }



        public TEntity Update(TEntity entity, string[] excluded)

        {

            _dbContext.Set<TEntity>().Update(entity);



            foreach (var property in excluded)

            {

                _dbContext.Entry(entity).Property(property).IsModified = false;

            }



            _dbContext.SaveChanges();



            return entity;

        }



        public void Delete(object id)

        {

            var entity = GetById(id);

            _dbContext.Set<TEntity>().Remove(entity);

            _dbContext.SaveChanges();

        }

        public void RemoveRange(Expression<Func<TEntity, bool>> where)

        {

            var entites = GetManyNoTracking(where);

            _dbContext.RemoveRange(entites);

            _dbContext.SaveChanges();

        }

        #endregion
    }
}
