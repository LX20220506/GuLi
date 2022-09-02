using glkt.EF;
using glkt.IRepository.Base;

namespace glkt.IRepository.Edu
{
    public interface ITeacherRepository:IRepositoryBase<EduTeacher> 
    {
        //软删除
        public void SoftDelete(EduTeacher teacher);
    }
}
