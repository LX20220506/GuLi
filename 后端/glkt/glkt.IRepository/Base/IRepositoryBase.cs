using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace glkt.IRepository.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);


        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);

        Task<T> GetByIdAsync(object id);

        Task<int> SaveAsync();


    }
}
