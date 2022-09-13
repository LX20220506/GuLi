using glkt.Common.Utils;
using glkt.EF;
using glkt.IService.Base;
using glkt.Model.Vo.Edu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.IService.Edu
{
    public interface ITeacherService:IServiceBase<EduTeacher>
    {
        Task<PageList> Page(int index, int size, EduTeacherSearchRequest? searchObj);
    }
}
