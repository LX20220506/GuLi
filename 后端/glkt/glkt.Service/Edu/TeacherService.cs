using ggkt.Service.Base;
using glkt.Common.Utils;
using glkt.EF;
using glkt.IRepository.Base;
using glkt.IRepository.Edu;
using glkt.IService.Edu;
using glkt.Model.Vo.Edu;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Service.Edu
{
    public class TeacherService : ServiceBase<EduTeacher>,ITeacherService
    {
        private readonly ITeacherRepository _repository;

        public TeacherService(ITeacherRepository repository) : base(repository)
        {
            this._repository = repository;
        }

        // 将物理删除改为软删除
        public override async Task<bool> Delete(EduTeacher entity)
        {
            _repository.SoftDelete(entity);
            return await _repository.SaveAsync()>0;
        }

        // 将物理删除改为软删除
        public override async Task<bool> DeleteById(object id)
        {
            EduTeacher entity = await _repository.GetByIdAsync(id);
            _repository.SoftDelete(entity);
            return await _repository.SaveAsync() > 0;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">每页显示多少条数据</param>
        /// <param name="searchObj">筛选条件</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<PageList> Page(int index, int size, EduTeacherSearchRequest? searchObj)
        {
            if (searchObj==null)
            {
                throw new Exception("筛选条件对象（searchObj）不能为null");
            }

            IQueryable<EduTeacher> data = _repository.GetAllAsync();


            if (!string.IsNullOrEmpty(searchObj.name))
            {
                data =data.Where(t => t.Name == searchObj.name);
            }

            if (searchObj.level != null && searchObj.level != 0)
            //if (!string.IsNullOrEmpty(searchObj.level))
            {
                data = data.Where(t => t.Level == searchObj.level);
            }

            if (!string.IsNullOrEmpty(searchObj.begin) )
            {
                data = data.Where(t => t.GmtCreate >= DateTime.Parse(searchObj.begin));
            }

            if (!string.IsNullOrEmpty(searchObj.end ))
            {
                data = data.Where(t => t.GmtCreate <= DateTime.Parse(searchObj.end));
            }

            // 执行查询操作
            List<EduTeacher> list = await data.OrderBy(t => t.GmtCreate).Skip((index-1)*size).Take(size).ToListAsync();

            // 封装数据
            return new PageList(list,index,size,list.Count);
        }


    }
}
