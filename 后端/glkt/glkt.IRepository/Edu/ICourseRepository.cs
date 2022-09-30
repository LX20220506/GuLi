using glkt.Common.Utils;
using glkt.EF;
using glkt.IRepository.Base;
using glkt.Model.VO.Edu;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.IRepository.Edu
{
    public interface ICourseRepository:IRepositoryBase<EduCourse>
    {
        public Task<PageList> CourseJoinSubjectJoinTeacher(int index,int size,EduCourseSearchRequest? search);

        /// <summary>
        /// 通过id获取发布课程之前，展示的课程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<CoursePublishResponse> GetCoursePublishVoById(string id);
    }
}
