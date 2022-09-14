using glkt.Common.Utils;
using glkt.EF;
using glkt.IRepository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace ggkt.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T :  class
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

        public virtual IQueryable<T> GetAllAsync()
        {
            return _dbContext.Set<T>();
            
        }

        public virtual IQueryable<T> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return  _dbContext.Set<T>().Where(expression);
        }


        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().Where(expression).SingleOrDefaultAsync();
        }

        /// <summary>
        /// 分页查询(弃用)
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">显示数据数</param>
        /// <param name="expression">筛选条件</param>
        /// <returns></returns>
        public PageList Page(int index, int size, Expression<Func<T, bool>> expression)
        {
            var count = _dbContext.Set<T>().Count();
            IQueryable<T> data = _dbContext.Set<T>().Where(expression).Skip((index - 1) * size).Take(size);

            return new PageList(data, index, size, count);
        }

        public async Task<PageList> Page(int index, int size)
        {
            var count = _dbContext.Set<T>().Count();
            // 注意这里需要使用OrderBy；
            // 因为ef使用的是反向工程，所有并没有ModelBase类或者接口，
            // 这里最好对泛型<T>做一个ModelBase的约束
            // 这样就可以使用条件排序了
            IEnumerable<T> data = await _dbContext.Set<T>().Skip((index-1) * size).Take(size).ToListAsync();

            return new PageList(data, index, size, count);
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
