using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Data.Infrastructure;
using System.Linq.Expressions;
using NPOI.SS.Formula.Functions;

namespace GP.ServicePattern
{
    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class
    {
    
        private readonly IUnitOfWork utwk;
        private readonly IRepositoryBase<TEntity> repository;
        private IRepositoryBase<T> repository1;
        private IRepositoryBase<T> repository2;

        public EntityService(IUnitOfWork _utwk, IRepositoryBase<TEntity> _repository)
        {
            this.utwk = _utwk;
            this.repository = _repository;

        }

        public EntityService(IUnitOfWork utwk, IRepositoryBase<T> repository1)
        {
            this.utwk = utwk;
            this.repository1 = repository1;
        }

      /*  public EntityService(IUnitOfWork utwk, IRepositoryBase<T> repository2)
        {
            this.utwk = utwk;
            this.repository2 = repository2;
        }*/

        public virtual void Add(TEntity entity)
        {
            repository.Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            repository.Update(entity);
        }
        public virtual void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }
        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            repository.Delete(where);
        }
        public virtual TEntity GetById(int id)
        {
            return repository.GetById(id);
        }
        public virtual TEntity GetById(string id)
        {
            return repository.GetById(id);
        }
        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
                return repository.GetMany(filter);
            else
                return repository.GetAll();
        }

    
        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return repository.Get(where);
        }
        public virtual void Dispose()
        {
            utwk.Dispose();
        }
        public void Commit()
        {
            try
            {
                utwk.Commit();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
