using glkt.IRepository.Base;
using glkt.IService.Base;
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

        public virtual async Task Add(T entity)
        {
            _repository.Add(entity);
            await _repository.SaveAsync();
        }

        public virtual async Task Delete(T entity)
        {
            _repository.Delete(entity);
            await _repository.SaveAsync();
        }

        public virtual async Task DeleteById(object id)
        {
            T entity = await _repository.GetByIdAsync(id);
            _repository.Delete(entity);
            await _repository.SaveAsync();

        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.GetAllAsync(expression);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task Update(T entity)
        {
            _repository.Update(entity);
            await _repository.SaveAsync();
        }
    }
}
