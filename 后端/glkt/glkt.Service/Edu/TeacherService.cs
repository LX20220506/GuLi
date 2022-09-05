using ggkt.Service.Base;
using glkt.EF;
using glkt.IRepository.Base;
using glkt.IRepository.Edu;
using glkt.IService.Edu;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
