using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Persistence
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        IEnumerable<TEntity> Get();
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> Search(ISpecification<TEntity> specification);
    }
}
