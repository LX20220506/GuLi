using glkt.Common.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace glkt.IService.Base
{
    public interface IServiceBase<T> where T : class
    {
        Task<bool> Add(T entity);

        Task<bool> DeleteById(object id); 

        Task<bool> Delete(T entity);

        Task<bool> Update(T entity);

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        public Task<T> GetEntityAsync(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);

        Task<PageList> Page(int index,int size,Expression<Func<T, bool>> expression);

        Task<PageList> Page(int index, int size);
    }
}
