using glkt.Common.Utils;
using glkt.IRepository.Base;
using glkt.IService.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace ggkt.Service.Base
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {

        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            this._repository = repository;
        }

        public virtual async Task<bool> Add(T entity)
        {
            _repository.Add(entity);
            return await _repository.SaveAsync()>0;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            _repository.Delete(entity);
            return await _repository.SaveAsync()>0;
        }

        public virtual async Task<bool> DeleteById(object id)
        {
            T entity = await _repository.GetByIdAsync(id);
            _repository.Delete(entity);
            return await _repository.SaveAsync()>0;

        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.GetAllAsync(expression).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<T> GetEntityAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.GetEntityAsync(expression);
        }

        public virtual async Task<PageList> Page(int index, int size, Expression<Func<T, bool>> expression)
        {
            var data =await _repository.GetAllAsync().Where(expression).Skip(index).Take(size).ToListAsync();
            return new PageList(data,index,size,data.Count);
        }

        public virtual async Task<PageList> Page(int index, int size)
        {
            return await _repository.Page(index, size);
        }

        public virtual async Task<bool> Update(T entity)
        {
            _repository.Update(entity);
            return await _repository.SaveAsync()>0;
        }
    }
}
