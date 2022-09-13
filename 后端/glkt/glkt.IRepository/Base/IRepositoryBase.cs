using glkt.Common.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        IQueryable<T> GetAllAsync();

        IQueryable<T> GetAllAsync(Expression<Func<T, bool>> expression);

        Task<T> GetEntityAsync(Expression<Func<T, bool>> expression);

        PageList Page(int index,int size,Expression<Func<T, bool>> expression);

        Task<PageList> Page(int index, int size);

        Task<T> GetByIdAsync(object id);

        Task<int> SaveAsync();


    }
}
