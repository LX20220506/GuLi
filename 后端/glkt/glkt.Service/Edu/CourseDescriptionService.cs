using ggkt.Service.Base;
using glkt.EF;
using glkt.IRepository.Base;
using glkt.IRepository.Edu;
using glkt.IService.Edu;
using glkt.Repository.Edu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Service.Edu
{
    public class CourseDescriptionService : ServiceBase<EduCourseDescription>, ICourseDescriptionService
    {
        private readonly ICourseDescriptionRepositoy _repository;

        public CourseDescriptionService(ICourseDescriptionRepositoy repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}
