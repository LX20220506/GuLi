using ggkt.Repository.Base;
using glkt.EF;
using glkt.IRepository.Edu;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Repository.Edu
{
    public class TeacherRepository : RepositoryBase<EduTeacher>, ITeacherRepository
    {
        private readonly GuLiDbContext _dbContext;

        public TeacherRepository(GuLiDbContext dbContext) : base(dbContext)// 注意这个地方不能直接注入DbContext类型对象
        {
            this._dbContext = dbContext;
        }

        // 软删除
        public void SoftDelete(EduTeacher teacher)
        {
            teacher.IsDeleted = 1;
            _dbContext.EduTeachers.Update(teacher);
        }
    }
}
