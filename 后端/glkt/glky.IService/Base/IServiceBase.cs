using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace glkt.IService.Base
{
    public interface IServiceBase<T> where T : class
    {
        Task Add(T entity);

        Task DeleteById(object id); 

        Task Delete(T entity);

        Task Update(T entity);

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
    }
}
