using Microsoft.EntityFrameworkCore;
using Reembolso.Data;
using Reembolso.Repository.IRepository;
using System.Linq.Expressions;

namespace Reembolso.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ReembolsoContext _db;
        internal DbSet<T> dbSet;

        public Repository(ReembolsoContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }

}
