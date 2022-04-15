using Core.Interfaces;
using Core.Interfaces.Persistence;

namespace Infrastructure.Persistence
{
    public abstract class EfRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected readonly ApplicationDbContext _context;

        public EfRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _context.Set<TEntity>().Update(entity).Entity;
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual IEnumerable<TEntity> Search(ISpecification<TEntity> specification)
        {
            return _context.Set<TEntity>()
                .Where(specification.Predicate)
                .ToList();
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
