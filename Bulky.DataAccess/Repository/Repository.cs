using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BulkyDbContext _bulkyDbContext;

        internal DbSet<T> _dbSet;

        public Repository(BulkyDbContext bulkyDbContext)
        {
            _bulkyDbContext = bulkyDbContext;
            _dbSet = _bulkyDbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;

            query = query.Where(filter);

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;

            return query.ToList();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
