using glkt.Common.Utils;
using glkt.EF;
using glkt.IService.Base;
using glkt.Model.VO.Edu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.IService.Edu
{
    public interface ICourseService:IServiceBase<EduCourse>
    {

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public Task<PageList> PageList(int index,int size,EduCourseSearchRequest? search);


        /// <summary>
        /// 保存课程和课程详情信息
        /// </summary>
        /// <param name="courseInfoForm"></param>
        /// <returns></returns>
        public Task<string> saveCourseInfo(EduCourseInfoForm courseInfoForm);


        /// <summary>
        /// 通过id拿到数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<EduCourseInfoForm> getCourseInfoFormById(string id);

        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="courseInfoForm"></param>
        /// <returns></returns>
        public Task UpdateCourseInfo( EduCourseInfoForm courseInfoForm);

        /// <summary>
        /// 通过课程id删除课程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task RemoveById(string id);

        /// <summary>
        /// 通过id获取发布课程之前，展示的课程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<CoursePublishResponse> GetCoursePublishVoById(string id);


        /// <summary>
        /// 发布课程（改变课程信息的状态）
        /// </summary>
        /// <param name="courseId">课程id</param>
        /// <returns></returns>
        Task PublishCourse(string courseId);
    }
}
