using glkt.IRepository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ggkt.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        private readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public virtual void Add(T entity)
        {
            _dbContext.Set<T>().AddAsync(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
            
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().Where(expression).ToListAsync();
        }


        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }


        public virtual async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }



        public virtual void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
